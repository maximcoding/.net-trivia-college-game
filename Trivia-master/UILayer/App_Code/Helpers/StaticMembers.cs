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
        public static Game _game = null;  //must be locked
        public static int _questionListWas; //must be locked
        public static IList<Question> _questionList = null;  //mus be locked
        public static Question question = null;


 //       private static volatile Singleton instance;
    //    private static object syncRoot = new Object();

        //  private Singleton() {}

        // public static Singleton Instance
        //  {
        //    get 
        //    {
        //      if (instance == null) 
        //      {
        //        lock (syncRoot) 
        //         {
        //           if (instance == null) 
        //              instance = new Singleton();
        //         }
        //     }

        //       return instance;
        //    }
        //  }
    }
}