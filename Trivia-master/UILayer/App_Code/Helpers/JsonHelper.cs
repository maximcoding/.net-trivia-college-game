using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI;

using App_Code.Helpers;

namespace App_Code.Helpers
{
    public  class JsonHelper<T> where T : class
    {
        public int status { get; set; }
        public string message { get; set; }
        public  IList<T> listData { get; set; }
        public  Object objData { get; set; }
        public  DataTable userData { get; set; }
        public  DataTable userGamesData { get; set; }
        public  int? totalGames { get; set; }
        public  int? totalScore { get; set; }
        public  int? place { get; set; }
    }
}