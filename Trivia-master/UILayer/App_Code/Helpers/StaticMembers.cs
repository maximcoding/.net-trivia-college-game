using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DALayer.Services;
using DALayer.Models;
using DALayer.Helpers;

namespace App_Code.Helpers
{
    public static class StaticMembers
    {
        public static int _questionNumber; // must be locked
        public static PlayerService _playerService;
        public static Game _game = null;  //must be locked
        public static int _questionListWas; //must be locked
        public static IList<Question> _questionList = null;  //mus be locked
        public static string _userCookMail = null; //must be locked
        public static int _userCookId; //must be locked
        public static Question question { set; get; }
        public static Player player { set; get; }
    }
}