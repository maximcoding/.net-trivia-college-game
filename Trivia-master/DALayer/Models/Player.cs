
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace DALayer.Models
{

    public  class Player
    {

        //Constructor // Setters & Getters 
        public Player()
        {
        }
        //Attributes // Setters & Getters 
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }          
        public DateTime registration_date { get; set; }
        public string image { get; set; }


      
    }
}
