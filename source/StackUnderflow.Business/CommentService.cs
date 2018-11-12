using System;
using System.Collections.Generic;
using System.Linq;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public class CommentService
    {
        private readonly StackUnderflowDbContext _context;
        private readonly UserHelper _userHelper;
        public CommentService(StackUnderflowDbContext context, UserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }


        //Add a comment
        public Comment AddComment(int responseId, string text, string username )
        {
            var addedComment = new Comment()
            {
                Text = text,
                ResponseId = responseId,
                CommentedBy = username,
                CommentedAt = DateTimeOffset.Now,
                Votes = 1,
                Inappropriate = false
            };
            _context.Comments.Add(addedComment);
            _context.SaveChanges();
            return addedComment;
        }

        //Get all comments
        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        //Find comment by Id
        public Comment FindCommentById(int id)
        {
            return _context.Comments.Find(id);
        }

        //Get all comments by responseId -- Order by votes, don't pull inappropriate
        public List<Comment> GetCommentsByResponse(int responseId)
        {
            return _context.Comments.Where(x => x.ResponseId == responseId).ToList();
        }

        //Edit a comment
        public void EditComment(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        //Delete a comment
        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        //Upvote a comment -- Do some user stuff here too
        public void UpvoteComment(Comment comment, string userId)
        {
            if(_userHelper.UserHasVotedComment(comment, userId))
            {
                return;
            }
            Comment upvotedComment = FindCommentById(comment.Id);
            CommentVote newVote = new CommentVote
            {
                CommentId = comment.Id,
                UserId = userId,
                Direction = true
            };
            _context.CommentVotes.Add(newVote);
            upvotedComment.Votes++;
            EditComment(upvotedComment);
        }

        //Downvote a comment
        public void DownvoteComment(Comment comment, string userId)
        {
            if (_userHelper.UserHasVotedComment(comment, userId))
            {
                return;
            }
            Comment downvoteComment = FindCommentById(comment.Id);
            CommentVote newVote = new CommentVote
            {
                CommentId = comment.Id,
                UserId = userId,
                Direction = false
            };
            downvoteComment.Votes++;
            _context.CommentVotes.Add(newVote);
            EditComment(downvoteComment);
        }

        //Mark comment inappropriate -- hide comment (make inactive)
        public void MarkCommentInappropriate(Comment comment)
        {
            comment.Inappropriate = true;
            EditComment(comment);
        }


    }
}
