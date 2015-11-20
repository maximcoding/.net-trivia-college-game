
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace DALayer.Models
{

    public class Category
    {


        //Constructor // Setters & Getters 
        public Category()
        {
        }
        //
        public Category(SqlDataReader reader)
        {
            id = Convert.ToInt32(reader["id"]);
            category_name = reader["category_name"].ToString();
            number_qustions = Convert.ToInt32(reader["number_qustions"]);
            picture = reader["number_qustions"].ToString();
        }

        public int id { get; set; }
        public string category_name { get; set; }
        public int? number_qustions { get; set; }   // int? null allow
        public string picture { get; set; }
    }
}
