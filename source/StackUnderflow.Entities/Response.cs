using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Entities
{
    public class Response
    {
        public Response()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string RespondedBy { get; set; }
        public DateTimeOffset RespondedAt { get; set; }
        public bool IsSolution { get; set; }
        public int Votes { get; set; }
        public bool IsActive { get; set; }
    }
}
