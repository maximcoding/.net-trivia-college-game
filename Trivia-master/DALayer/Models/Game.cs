
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Models
{
    public class Game
    {


        //Constructor // Setters & Getters 
        public Game()
        {
        }
        //Attributes// Setters & Getters 
        public int id { get; set; }
        public int played_category_id { get; set; }
        public int player_id { get; set; }
        public int? score { get; set; } //int? null allow
        public int? number_right_questions { get; set; } //int? null allow
        public DateTime played_date { get; set; }
    }
}
