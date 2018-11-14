using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public class ResponseService
    {
        private readonly StackUnderflowDbContext _context;

        public ResponseService(StackUnderflowDbContext context)
        {
            _context = context;
        }
        //Add a response
        public Response AddResponse(string text, string userId, int questionId)
        {
            Response response = new Response()
            {
                Text = text,
                QuestionId = questionId,
                RespondedBy = userId,
                RespondedAt = DateTimeOffset.Now,
                IsSolution = false,
                Votes = 1,
                Inappropriate = false,
                MarkAsDeleted = false
            };
            _context.Responses.Add(response);
            _context.SaveChangesAsync();
            return response;
        }
        
        //Get all responses by questionId -- Order by votes, don't pull inappropriate

        public List<Response> GetResponsesByQuestionId(int id)
        {
            return _context.Responses.Where(x => x.QuestionId == id && x.Inappropriate == false).ToList();
        }
        
        //Delete a response

        public Response DeleteResponse(int id)
        {
            var response = _context.Responses.Where(x => x.Id == id).FirstOrDefaultAsync().Result;
            response.MarkAsDeleted = true;
            _context.SaveChangesAsync();
            return response;
        }
        
        public Response FindResponseId(int id)
        {
            return _context.Responses.Find(id);
        }
        
        //Upvote/Downvote a response
        
        public void UpvoteResponse(int responseId)
        {
            var upvotedResponse = FindResponseId(responseId);
            upvotedResponse.Votes++;
            _context.Responses.Update(upvotedResponse);
            _context.SaveChanges();
        }

        public void DownvoteResponse(int questionId)
        {
            var downvotedResponse = FindResponseId(questionId);
            downvotedResponse.Votes--;
            _context.Responses.Update(downvotedResponse);
            _context.SaveChanges();
        }
        
        //Mark response inappropriate
        
        public Response MarkResponseAsInappropriate(int id)
        {
            var response = _context.Responses.Where(x => x.Id == id).FirstOrDefaultAsync().Result;
            response.Inappropriate = true;
            _context.SaveChangesAsync();
            return response;
        }
        
        //Mark response as solution - Also need to update question to have that be solution
        
        public Response MarkResponseAsSolution(int id)
        {
            var response = _context.Responses.Where(x => x.Id == id).FirstOrDefaultAsync().Result;
            var question = _context.Questions.Where(x => x.Id == response.QuestionId).FirstOrDefaultAsync().Result;
            response.IsSolution = true;
            question.ResponseSolutionId = response.Id;
            _context.SaveChangesAsync();
            return response;
        }
    }
}
