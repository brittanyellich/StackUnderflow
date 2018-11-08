using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Entities
{
    public class ResponseVote
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public string UserId { get; set; }
        public bool Direction { get; set; }
    }
}
