using System;
using System.Collections.Generic;

namespace TriviaGame
{

    public class Answer
    {

      //Constructor  
        public Answer()
        {

        }
        // Atributes // Setters & Getters
        private int id { get; set; }
        public int question_id { get; set; }
        public string answer { get; set; }
        public bool? is_right { get; set; }
    }
}
