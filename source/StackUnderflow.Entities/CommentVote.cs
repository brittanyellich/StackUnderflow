using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Entities
{
    public class CommentVote
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public bool Direction { get; set; }
    }
}
