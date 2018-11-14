using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            _context.Questions.Update(question);
            _context.SaveChanges();

        }

        public void MarkAsInappropriate(int id)
        {
            FindQuestionById(id).Inappropriate = true;
            _context.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public void UpvoteQuestion(int questionId)
        {
            var upvotedQuestion = FindQuestionById(questionId);
            upvotedQuestion.Votes++;
            EditQuestion(upvotedQuestion);
        }

        public void DownvoteQuestion(int questionId)
        {
            var downvotedQuestion = FindQuestionById(questionId);
            downvotedQuestion.Votes--;
            EditQuestion(downvotedQuestion);
        }
        //Mark question inappropriate (Stretch goal)
        //Search questions (stretch goal)
    }

}
