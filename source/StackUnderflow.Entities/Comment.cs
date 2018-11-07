using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StackUnderflow.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CommentedBy { get; set; }
        public DateTimeOffset CommentedAt { get; set; }
        public int Votes { get; set; }
        public bool IsActive { get; set; }
    }
}