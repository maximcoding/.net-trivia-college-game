
using System;
using System.Collections.Generic;

namespace TriviaGame
{
    public class Question
    {


        //Constructor // Setters & Getters 
        public Question()
        {
        }
        //Attributes// Setters & Getters 
        public int id { get; set; }
        public int category_id { get; set; }
        public string question_type { get; set; }
        public string question { get; set; }
        public string image { get; set; }
        public int points { get; set; }

    }
}
