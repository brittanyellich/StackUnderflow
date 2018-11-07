using System;
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
                Responses = null,
                Comments = null,
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
    }
}
