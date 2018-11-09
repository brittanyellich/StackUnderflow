using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public string RespondedBy { get; set; }
        public DateTimeOffset RespondedAt { get; set; }
        public bool IsSolution { get; set; }
        public int Votes { get; set; }
        public bool Inappropriate { get; set; }
        public bool MarkAsDeleted { get; set; }
    }
}
