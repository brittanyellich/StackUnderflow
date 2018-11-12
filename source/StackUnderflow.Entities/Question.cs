using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace StackUnderflow.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AskedBy { get; set; }
        public DateTimeOffset AskedAt { get; set; }
        public int ResponseSolutionId { get; set; }
        public int Votes { get; set; }
        public Topic Topic { get; set; }
        public bool Inappropriate { get; set; }
    }

    public enum Topic
    {
        Programming,
        Animals,
        Cars,
        Computers, 
        Sweaters,
        Fashion,
        Sneakers,
        Music,
        VideoGames,
        Pizza,
        Beer,
        OtherAlcoholicBeverages
    }
}
