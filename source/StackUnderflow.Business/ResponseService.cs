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
    class ResponseService
    {
        private readonly StackUnderflowDbContext _context;

        public ResponseService(StackUnderflowDbContext context)
        {
            _context = context;
        }
        //Add a response
        public Response AddResponse(Response response)
        {
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
        
        
        //Upvote/Downvote a response
        
        public ResponseVote ResponseVote(ResponseVote vote)
        {
            var response = _context.Responses.Where(x => x.Id == vote.ResponseId).FirstOrDefaultAsync().Result;
            response.Votes = vote.Direction ? response.Votes+1 : response.Votes-1;
            _context.ResponseVotes.Add(vote);
            _context.SaveChangesAsync();
            return vote;
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
