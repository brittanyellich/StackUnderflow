using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflow.Entities;

namespace StackUnderflow.Business
{
    public class CommentService
    {
        //Add a comment
        //Get all comments by responseId -- Order by votes, don't pull inappropriate
        //See a comment by responsesId
        //Edit a comment
        //Delete a comment
        //Upvote a comment -- Do some user stuff here too
        //Downvote a comment
        //Mark comment inappropriate -- hide comment (make inactive)

        public Comment AddComment()
        {
            return new Comment();
        }
    }
}
