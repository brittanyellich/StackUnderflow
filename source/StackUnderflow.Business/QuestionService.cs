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
                IsActive = true
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
            return _context.Questions.ToList();
        }

        public void EditQuestion(Question question)
        {
            _context.Questions.Update(question);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public void UpvoteQuestion(Question question, string userId)
        {
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

    }
}
