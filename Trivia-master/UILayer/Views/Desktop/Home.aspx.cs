using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using System.Windows;
using DALayer.Models;
using DALayer.Services;
using DALayer.Helpers;
using App_Code.Helpers;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TriviaGame.Views.Desktop
{
    public partial class Home : System.Web.UI.Page
    {
        private Guid uidForImage;
        public Size OriginalImageSize { get; set; }        //Store original image size.
        public Size NewImageSize { get; set; }
        private JsonHelper<Object> _jsonHelper = null;
        PlayerService _playerService = null;
        private CometClientProcessor _cometProcessor;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                SetDefaultView();
            }
        }

        private void SetDefaultView()
        {
            MultiView.ActiveViewIndex = 0;
        }

        protected void Hide_Click(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Login(LoginEmail.Text, LoginPass.Text);
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            uidForImage = Guid.NewGuid();
            string fileName = System.IO.Path.GetFileName(PictureUpload.PostedFile.FileName);
            _playerService = new PlayerService();
            _jsonHelper = new JsonHelper<Object>();
            Player newPlayer = new Player();
            newPlayer.username = RegisterUsername.Text;
            newPlayer.email = RegisterEmail.Text;
            // kod zashivrovali v settere 
            newPlayer.password = RegisterPassword.Text;
            newPlayer.image = uidForImage + fileName;
            newPlayer.registration_date = DateTime.Now;

            if (!_playerService.CheckIfExists(newPlayer))
            {
                // do stuff here to log the user in ... 
                if (_playerService.Insert(newPlayer))
                {
                    UploadImage(sender, e);
                    Login(newPlayer.email, newPlayer.password);
                }
            }
            else
            {
                string message = "<div class='alert alert-warning'>This email is registered,Please login or register another one</div>";
                Alert.Text = message;
                Response.Redirect("Home.aspx");
            }
        }

        private void Login(string email, string pass)
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
                player = _playerService.FindByEmail(LoginEmail.Text);
                // Create  Cookie
                HttpCookie time = new HttpCookie("LastLogined", DateTime.Now.ToString());
                HttpCookie userEmail = new HttpCookie("userEMail", player.email);
                HttpCookie userId = new HttpCookie("userId", player.id.ToString());
                time.Expires = DateTime.Now.AddDays(1);
                userEmail.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(time);
                HttpContext.Current.Response.Cookies.Add(userEmail);
                HttpContext.Current.Response.Cookies.Add(userId);
                HttpContext.Current.Session["Email"] = player.email;
                HttpContext.Current.Session["Username"] = player.username;
                Response.Redirect("Games.aspx"); //if true - so code after this not working - its abort the thread
            }
            else
            {
                string message = "<div class='alert alert-warning'>This email and password not found,Please register or try again</div>";
                Alert.Text = message;
            }
        }

        protected void BackToLoginView_Click(object sender, EventArgs e)
        {
            if (MultiView.ActiveViewIndex == 1)
            {
                MultiView.ActiveViewIndex = 0;
            }
            else
            {
                MultiView.ActiveViewIndex -= 1;
            }
        }
        protected void MoveToRegisterView_Click(object sender, EventArgs e)
        {
            if (MultiView.ActiveViewIndex == 0)
            {
                MultiView.ActiveViewIndex = 1;
            }
            else
            {
                MultiView.ActiveViewIndex -= 1;
            }
        }



        private void UploadImage(object sender, EventArgs e)
        {
            string imgPath = "~/Content/img/avatars/";
            Alert.Text = "";
            if ((PictureUpload.PostedFile != null) && (PictureUpload.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(PictureUpload.PostedFile.FileName);
                string SaveLocation = Server.MapPath(imgPath) + "" + uidForImage + fileName;
                try
                {
                    string fileExtention = PictureUpload.PostedFile.ContentType;
                    int fileLenght = PictureUpload.PostedFile.ContentLength;
                    if (fileExtention == "image/png" || fileExtention == "image/jpeg" || fileExtention == "image/x-png")
                    {
                        if (fileLenght <= 1048576)
                        {
                            System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(PictureUpload.PostedFile.InputStream);
                            System.Drawing.Image objImage = ScaleImage(bmpPostedImage, 81);
                            // Saving image in jpeg format
                            objImage.Save(SaveLocation, ImageFormat.Jpeg);
                            Alert.Text = "The file has been uploaded.";
                        }
                        else
                        {
                            Alert.Text = "Image size cannot be more then 1 MB.";
                        }
                    }
                    else
                    {
                        Alert.Text = "Invaild Format!";
                    }
                }
                catch (Exception ex)
                {
                    Alert.Text = "Error: " + ex.Message;
                }
            }
        }


        // Resizes Images
        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }

}