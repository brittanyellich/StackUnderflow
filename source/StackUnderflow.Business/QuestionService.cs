using System;
using System.Collections.Generic;
using System.Linq;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public class QuestionService
    {
        private readonly StackUnderflowDbContext _context;

        public QuestionService(StackUnderflowDbContext context)
        {
            _context = context;
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
            return questionToAdd;
        }

        public Question FindQuestionById(int id)
        {
            return _context.Questions.Find(id);
        }

        public List<Question> GetAllQuestions()
        {
            //Order by votes, don't pull inappropriate
            return _context.Questions.ToList();
        }

        public void EditQuestion(Question question)
        {
            //If we get to it, make it so only the author can edit
            _context.Questions.Update(question);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public void UpvoteQuestion(Question question, string userId)
        {
            //handle that user hasn't already upvoted/downvoted the question
            Question upvotedQuestion = FindQuestionById(question.Id);
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
            //handle that user hasn't already upvoted/downvoted the question
            Question downvotedQuestion = FindQuestionById(question.Id);
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
