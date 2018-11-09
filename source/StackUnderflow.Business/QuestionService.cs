using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public class QuestionService
    {
        private readonly StackUnderflowDbContext _context;
        private readonly UserHelper _userHelper;

        public QuestionService(StackUnderflowDbContext context, UserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public Question AddQuestion(string text, Topic topic, string userName)
        {
            var questionToAdd = new Question
            {
                Text = text,
                AskedBy = userName,
                AskedAt = DateTimeOffset.Now,
                ResponseSolutionId = 0,
                Votes = 1,
                Topic = topic,
                Inappropriate = false
            };
            _context.Questions.Add(questionToAdd);
            _context.SaveChanges();
            return questionToAdd;
        }

        public Question FindQuestionById(int id)
        {
            return _context.Questions.Find(id);
        }

        public List<Question> GetAllQuestions()
        {
            var questions = _context.Questions.Where(x => !x.Inappropriate);
            return questions.OrderBy(x => x.Votes).ToList();
        }

        public void EditQuestion(Question question)
        {
            //If we get to it, make it so only the author can edit
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public void UpvoteQuestion(Question question, string userId)
        {
            Question upvotedQuestion = FindQuestionById(question.Id);
            if (_userHelper.UserHasVotedQuestion(upvotedQuestion, userId))
            {
                return;
            }
            
            QuestionVote newVote = new QuestionVote
            {
                QuestionId = question.Id,
                UserId = userId,
                Direction = true
            };
            
            upvotedQuestion.Votes++;
            EditQuestion(upvotedQuestion);
            
            
        }

        public void DownvoteQuestion(Question question, string userId)
        {
            Question downvotedQuestion = FindQuestionById(question.Id);
            if (_userHelper.UserHasVotedQuestion(downvotedQuestion, userId))
            {
                return;
            }
            QuestionVote newVote = new QuestionVote
            {
                QuestionId = question.Id,
                UserId = userId,
                Direction = false
            };
            downvotedQuestion.Votes--;
            EditQuestion(downvotedQuestion);
        }
        //Mark question inappropriate (Stretch goal)
        //Search questions (stretch goal)
    }

}
