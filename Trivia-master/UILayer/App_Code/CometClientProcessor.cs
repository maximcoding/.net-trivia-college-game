using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Data;

using DALayer.Services;
using DALayer.Models;
using App_Code.Helpers;

public class CometClientProcessor
{
    private static Object _lockObjStatic; // locks only static not - thead-safe resourses
    private static List<CometAsyncResult> _clientStateListStatic;  //must be locked


    static CometClientProcessor()
    {
        _lockObjStatic = new Object();
        _clientStateListStatic = new List<CometAsyncResult>();
    }

    private CategoryService _categoryService;
    private QuestionService _questionService;
    private AnswerService _answerService;
    private GameService _gameService;
    private PlayerService _playerService;
    private List<Answer> _answerList;
    private JsonHelper<Answer> _jsonHelperA = null;
    private JsonHelper<Category> _jsonHelperC = null;
    private IList<Answer> _answersList = null; // every time it is a new




    public CometClientProcessor()
    {
        // Dependency Injection (design pattern ) implementation/realization other class in Constructor
        this._categoryService = new CategoryService();
        this._questionService = new QuestionService();
        this._answerService = new AnswerService();
        this._gameService = new GameService();
    }

    //Example that sends to all clients the same as broadcast WHen someone PUSH it 
    public static void PushData(String someText)
    {
        List<CometAsyncResult> currentStateList = new List<CometAsyncResult>();

        lock (_lockObjStatic)
        {
            foreach (CometAsyncResult clientState in _clientStateListStatic)   // adding this client state to List 
            {
                currentStateList.Add(clientState);
            }
        }

        foreach (CometAsyncResult clientState in currentStateList) // response to all clients with it new result state
        {
            if (clientState.HttpContext.Session != null)
            {
                clientState.HttpContext.Response.Write(someText);
                clientState.CompleteRequest();
            }
        }
    }

    // Extension method for LoginConnectAddClient method
    public static void AddClient(CometAsyncResult state)
    {
        Guid newGuid;

        lock (_lockObjStatic)
        {
            while (true)
            {
                newGuid = Guid.NewGuid();
                if (_clientStateListStatic.Find(s => s.ClientGuid == newGuid) == null)
                {
                    state.ClientGuid = newGuid;
                    break;
                }
            }

            _clientStateListStatic.Add(state);
        }
    }
    // Extension method for LogoutDisconnectRemoveClient method
    public static void RemoveClient(CometAsyncResult state)
    {
        lock (_lockObjStatic)
        {
            _clientStateListStatic.Remove(state);
        }
    }
    // Extension method for getUserInfo,continueGame methods
    public static void UpdateClient(CometAsyncResult state, String clientGuidKey)
    {
        Guid clientGuid = new Guid(clientGuidKey);

        lock (_lockObjStatic)
        {
            // checks if this state founded
            CometAsyncResult foundState = _clientStateListStatic.Find(s => s.ClientGuid == clientGuid);
            //Update this client state if this state found ( prepare for to add to all Clients State List )
            if (foundState != null)
            {
                foundState.HttpContext = state.HttpContext;
                foundState.ExtraData = state.ExtraData;
                foundState.AsyncCallBack = state.AsyncCallBack;
            }
        }
    }


    // must be static only because its has extension static method "RemoveClient"
    public void LogoutDisconnect(CometAsyncResult state)
    {
        RemoveClient(state); // extension static method Disconnecting
    }

    // Games allways the same content ..must be loaded one time only 
    public IList<Category> getGames(CometAsyncResult state)
    {
        return _categoryService.GetAll();
    }

    public void startGame(CometAsyncResult state, int categoryId)
    {

        //    int catId = Convert.ToInt32(categoryId);
        StaticMembers._questionList = new List<Question>();
        StaticMembers._questionList = _questionService.GetQuestionsByCategoryId(categoryId);
        StaticMembers._questionListWas = StaticMembers._questionList.Count();
        StaticMembers._game = new Game();
        StaticMembers._game.played_category_id = categoryId;
        StaticMembers._game.played_date = DateTime.Now;
        StaticMembers._game.score = 0;
        StaticMembers._game.number_right_questions = 0;
        StaticMembers._game.player_id = Convert.ToInt32(StaticMembers._userCookMail = state.HttpContext.Request.Cookies["userId"].Value);
        if (_gameService.Insert(StaticMembers._game))
        {
            StaticMembers._questionNumber = 0;
            continueGame(true, 0);
        }
    }

    // must be static for to return in Real-Time to every client new User Information only if someone it changes 
    public static void pushUserData(string anyData)
    {

        List<CometAsyncResult> currentStateList = new List<CometAsyncResult>();

        lock (_lockObjStatic)
        {
            foreach (CometAsyncResult clientState in _clientStateListStatic)
            {
                currentStateList.Add(clientState);
            }
        }

        foreach (CometAsyncResult clientState in currentStateList)
        {
            if (clientState.HttpContext.Session != null)
            {
                string strJSON = Newtonsoft.Json.JsonConvert.SerializeObject(anyData);
                clientState.HttpContext.Response.Write(strJSON);
                clientState.CompleteRequest();
            }
        }
    }

    public static bool continueGame(Boolean nextIsPressed, int scoreForQuestion)
    {
        if (nextIsPressed && (!StaticMembers._questionList.Count().Equals(0)))
        {
            StaticMembers.question = StaticMembers._questionList.First();
            StaticMembers._questionNumber += 1;
            nextIsPressed = false;
            StaticMembers._questionList.Remove(StaticMembers.question);
            if (!scoreForQuestion.Equals(0))
            {
                StaticMembers._game.number_right_questions += 1;
                StaticMembers._game.score += scoreForQuestion;
                GameService.Update(StaticMembers._game);
            }
        }

        if (nextIsPressed && StaticMembers._questionList.Count().Equals(0))
        {
            return false;
        }
        return true;
    }


}
