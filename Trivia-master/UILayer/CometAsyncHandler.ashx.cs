
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

using App_Code.Helpers;
using DALayer.Models;
using CometAsyncCode;
using DALayer.Services;


public class CometAsyncHandler : IHttpAsyncHandler, System.Web.SessionState.IRequiresSessionState
{

    static private ThreadPool _threadPool;
    private CometAsyncResult currentAsyncRequestState;

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
                _curAsyncResult.CompleteRequest();
                break;

            case "continueGame":
                bool play = Convert.ToBoolean(values["gameAction"]);
                int score = Convert.ToInt32(values["score"]);
                while (CometClientProcessor.continueGame(play, score))
                {
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
                 // MUST NOT TO HAVE COMPLETE REQUEST
                }
                // when games End - show last Game Result;
                JsonHelper<Game> _jsonHelperGameResult = new JsonHelper<Game>();
                _jsonHelperGameResult.status = 20; // end game 
                _jsonHelperGameResult.objData = GameService.GetPlayersLastGameResult(StaticMembers._game.player_id);
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelperGameResult);
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                _curAsyncResult.CompleteRequest();
                break;


            case "getUserInfo":
                string thisEmailisOk = values["userinfo"].ToString();
                PlayerService playerService = new PlayerService();
                Player player = playerService.FindByEmail(thisEmailisOk);
                HttpCookie userId = new HttpCookie("userId", player.id.ToString());
                _jsonHelper.status = 30; // 30  Fresh user info Loaded
                _jsonHelper.userData = PlayerService.GetProfileInfo(player.id); // returns Players Info
                _jsonHelper.userGamesData = PlayerService.GetPlayerAllStats(player.id); // returns all info about users games
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                _curAsyncResult.HttpContext.Response.Write(responseJSON);
                break;

        }

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
