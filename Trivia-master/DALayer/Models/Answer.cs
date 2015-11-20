using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Models
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
