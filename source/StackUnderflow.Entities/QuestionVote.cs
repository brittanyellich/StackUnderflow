using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Entities
{
    public class QuestionVote
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public bool Direction { get; set; }

    }
}
