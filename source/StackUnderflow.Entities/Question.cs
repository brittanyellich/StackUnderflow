using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace StackUnderflow.Entities
{
    public class Question
    {
        public Question()
        {
            this.Responses = new HashSet<Response>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string AskedBy { get; set; }
        public DateTimeOffset AskedAt { get; set; }
        public int ResponseSolutionId { get; set; }
        public int Votes { get; set; }
        public Topic Topic { get; set; }
        public bool IsActive { get; set; }
    }

    public enum Topic
    {
        Programming,
        Animals,
        Cars,
        Computers
    }
}
