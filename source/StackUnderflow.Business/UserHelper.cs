using System.Linq;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public  class UserHelper
    {
        private readonly StackUnderflowDbContext _context;

        public UserHelper(StackUnderflowDbContext context)
        {
            _context = context;
        }
        
        public bool UserHasVotedQuestion(Question item, string userId)
        {
            return _context.QuestionVotes.Any(x => x.UserId == userId && x.QuestionId == item.Id);
        }     
        public bool UserHasVotedResponse(Response item, string userId)
        {
            return _context.QuestionVotes.Any(x => x.UserId == userId && x.QuestionId == item.Id);
        }    
        public bool UserHasVotedComment(Comment item, string userId)
        {
            return _context.QuestionVotes.Any(x => x.UserId == userId && x.QuestionId == item.Id);
        } 
    }
}