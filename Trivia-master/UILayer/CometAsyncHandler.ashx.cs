
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using System.Web.SessionState;

using App_Code.Helpers;
using DALayer.Models;
using CometAsyncCode;
using DALayer.Services;


public class CometAsyncHandler : IHttpAsyncHandler, IReadOnlySessionState
{

    static private ThreadPool _threadPool;
    private CometAsyncResult currentAsyncRequestState;
    private JsonHelper<Object> _jsonHelper = null;
    PlayerService _playerService = null;
    private CometClientProcessor _cometProcessor;

    static CometAsyncHandler()
    {
        _threadPool = new ThreadPool(2, 50, "Comet Pool");
        _threadPool.PropogateCallContext = true;
        _threadPool.PropogateThreadPrincipal = true;
        _threadPool.PropogateHttpContext = true;
        _threadPool.Start();
    }


    public IAsyncResult BeginProcessRequest(HttpContext ctx, AsyncCallback cb, Object obj)
    {
        currentAsyncRequestState = new CometAsyncResult(ctx, cb, obj);
        _threadPool.PostRequest(new WorkRequestDelegate(ProcessServiceRequest), currentAsyncRequestState);

        return currentAsyncRequestState;
    }



    private void ProcessServiceRequest(Object state, DateTime requestTime)
    {
        string responseJSON = null;
        JsonHelper<Object> _jsonHelper = new JsonHelper<Object>();
        CometAsyncResult _curAsyncResult = state as CometAsyncResult;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        CometClientProcessor _cometProcessor = new CometClientProcessor();
        _curAsyncResult.HttpContext.Request.InputStream.Position = 0;
        string jsonRequest = new StreamReader(_curAsyncResult.HttpContext.Request.InputStream).ReadToEnd();
        Dictionary<string, string> values = serializer.Deserialize<Dictionary<string, string>>(jsonRequest);


        string command = values["command"];

        switch (command)
        {
            case "CONNECT":
                CometClientProcessor.AddClient(_curAsyncResult);
                _curAsyncResult.HttpContext.Response.Write(_curAsyncResult.ClientGuid.ToString());
                _curAsyncResult.CompleteRequest();
                break;

            case "DISCONNECT":
                CometClientProcessor.RemoveClient(_curAsyncResult);
                _curAsyncResult.CompleteRequest();
                break;

            case "CLIENTGUID":
                if (values["ClientID"] != null)
                {
                    CometClientProcessor.UpdateClient(_curAsyncResult, values["ClientID"].ToString());
                }
                break;

            case "login":
                    Login(_curAsyncResult, values["email"], values["password"]);
                break;

            case "register":
                    Register(_curAsyncResult, values["email"], values["username"], values["password"], values["passConfirm"]);             
                break;


            case "logout":
                CometClientProcessor.RemoveClient(_curAsyncResult);
                _curAsyncResult.HttpContext.Response.Cookies["LastLogined"].Expires = DateTime.Now.AddDays(-1);
                _curAsyncResult.HttpContext.Response.Cookies["userEMail"].Expires = DateTime.Now.AddDays(-1);
                _jsonHelper.status = 1000; // status 1000 logout
                _jsonHelper.message = "GoodBye ";
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                _curAsyncResult.HttpContext.Response.Headers.Add("Content-type", "application/json");
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                _curAsyncResult.CompleteRequest();
                break;

            case "getGames":
                JsonHelper<Category> _jsonHelperGames = new JsonHelper<Category>();
                _jsonHelperGames.status = 200; //getGames 
                _jsonHelperGames.listData = _cometProcessor.getGames(_curAsyncResult);
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelperGames);
                _curAsyncResult.HttpContext.Response.Headers.Add("Content-type", "application/json");
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                _curAsyncResult.CompleteRequest();
                break;

            case "startGame":
                int catId = Convert.ToInt32(values["categoryId"]);
                _cometProcessor.startGame(_curAsyncResult, catId);
                JsonHelper<Answer> _jsonHelperQandAnswers = new JsonHelper<Answer>();
                // Cleaning Buffer for each response to client
                _curAsyncResult.HttpContext.Response.BufferOutput = false;
                _curAsyncResult.HttpContext.Response.Flush();
                _jsonHelperQandAnswers.status = 10; // Continue Game
                _jsonHelperQandAnswers.message = StaticMembers._questionNumber + " / " + StaticMembers._questionListWas; ;
                _jsonHelperQandAnswers.objData = StaticMembers.question;
                _jsonHelperQandAnswers.listData = AnswerService.getAllByQuestionId(StaticMembers.question.id);
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelperQandAnswers);
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                _curAsyncResult.CompleteRequest();
                break;

            case "continueGame":
                bool play = Convert.ToBoolean(values["gameAction"]);
                int score = Convert.ToInt32(values["score"]);
                GameService _gameService = new GameService();
                if (_cometProcessor.continueGame(play, score))
                {
                    JsonHelper<Answer> _jsonHelperQandAns = new JsonHelper<Answer>();
                    // Cleaning Buffer for each response to client
                    _curAsyncResult.HttpContext.Response.BufferOutput = false;
                    _curAsyncResult.HttpContext.Response.Flush();
                    _jsonHelperQandAns.status = 10; // Continue Game
                    _jsonHelperQandAns.message = StaticMembers._questionNumber + " / " + StaticMembers._questionListWas; ;
                    _jsonHelperQandAns.objData = StaticMembers.question;
                    _jsonHelperQandAns.listData = AnswerService.getAllByQuestionId(StaticMembers.question.id);
                    responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelperQandAns);
                    _curAsyncResult.HttpContext.Response.Write(responseJSON);
                    _curAsyncResult.CompleteRequest();
                }
                // when games End - show last Game Result;
                JsonHelper<Game> _jsonHelperGameResult = new JsonHelper<Game>();
                _jsonHelperGameResult.status = 20; // end game 
                _jsonHelperGameResult.objData = _gameService.GetPlayersLastGameResult(StaticMembers._game.player_id);
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelperGameResult);
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                _curAsyncResult.CompleteRequest();
                break;


            case "getUserInfo":
                string _email = _curAsyncResult.HttpContext.Session["Email"].ToString();
                PlayerService playerService = new PlayerService();
                Player player = playerService.FindByEmail(_email);
                HttpCookie userId = new HttpCookie("userId", player.id.ToString());
                _jsonHelper.status = 30; // 30  Fresh user info Loaded
                _jsonHelper.userData = PlayerService.GetProfileInfo(player.id); // returns Players Info
                _jsonHelper.userGamesData = PlayerService.GetPlayerAllStats(player.id); // returns all info about users games
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                _curAsyncResult.CompleteRequest();
                break;

        }

    }
    private void Register(CometAsyncResult clientState, string email, string user, string pass, string passConfirm)
    {
        _playerService = new PlayerService();
        _jsonHelper = new JsonHelper<Object>();
        string responseJSON = null;
        if (email != "" &&
            user != "" &&
            pass != "" &&
            email != "" &&
            pass == passConfirm)
        {
            Player newPlayer = new Player();
            newPlayer.email = email;
            newPlayer.username = user;
            // kod zashivrovali v settere 
            newPlayer.password = pass;
            newPlayer.image = "ehse netu picture";
            newPlayer.registration_date = DateTime.Now;

            if (!_playerService.CheckIfExists(newPlayer))
            {
                System.Threading.Thread.Sleep(1000);
                // do stuff here to log the user in ... 
                if (_playerService.Insert(newPlayer))
                {
                    System.Threading.Thread.Sleep(1000);
                    Login(clientState, newPlayer.email, newPlayer.password);
                }
            }
            else
            {
                _jsonHelper.status = 405;
                _jsonHelper.message = "This email is registered,Please login or register another one";
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                clientState.HttpContext.Response.Headers.Add("Content-type", "application/json");
                clientState.HttpContext.Response.Write(responseJSON);
            }
        }
        else
        {

            _jsonHelper.status = 406;
            _jsonHelper.message = "All fields required Or passwords doesn't match!";
            responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
            HttpContext.Current.Response.Headers.Add("Content-type", "application/json");
            HttpContext.Current.Response.Write(responseJSON);
        }
    }

    private void Login(CometAsyncResult clientState, string email, string pass)
    {
        _jsonHelper = new JsonHelper<object>();
        _cometProcessor = new CometClientProcessor();
        _playerService = new PlayerService();
        Player player = new Player();
        player.password = pass;
        player.email = email;
        _playerService = new PlayerService();
        if (_playerService.Verify(player))
        {
            player = _playerService.FindByEmail(email);
            // Create  Cookie
            HttpCookie time = new HttpCookie("LastLogined", DateTime.Now.ToString());
            HttpCookie userEmail = new HttpCookie("userEMail", player.email);
            HttpCookie userId = new HttpCookie("userId", player.id.ToString());
            time.Expires = DateTime.Now.AddDays(1);
            userEmail.Expires = DateTime.Now.AddDays(1);
            clientState.HttpContext.Response.Cookies.Add(time);
            clientState.HttpContext.Response.Cookies.Add(userEmail);
            clientState.HttpContext.Response.Cookies.Add(userId);
            clientState.HttpContext.Session["Email"] = player.email;
            clientState.HttpContext.Session["Username"] = player.username;

            _jsonHelper.message = "Welcome " + player.username + "!";
            _jsonHelper.status = 200;
            string responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
            clientState.HttpContext.Response.Write(responseJSON);
        }
        else
        {
            _jsonHelper.message = "This email and password not found,Please register or try again";
            _jsonHelper.status = 404;
            string responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
            clientState.HttpContext.Response.Write(responseJSON);

        }
        clientState.CompleteRequest();
    }

    public void EndProcessRequest(System.IAsyncResult result)
    {
    }

    public bool IsReusable
    {
        get { throw new System.NotImplementedException(); }
    }

    public void ProcessRequest(HttpContext context)
    {
    }

}
