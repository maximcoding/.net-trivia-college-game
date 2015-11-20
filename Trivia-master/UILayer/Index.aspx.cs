using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Web.UI.WebControls;

namespace TriviaGame
{
    public partial class Index : System.Web.UI.Page
    {
        private bool ISMOBILE_DEVICE;

        protected void Page_Load(object sender, EventArgs e)
        {
            XDocument mobileDeviceDoc = XDocument.Load(Server.MapPath("~/App_Data/MobileDevices.xml"));

            var mobileDevices = from devices in mobileDeviceDoc.Root.Elements()
                                select devices;

            foreach (XElement device in mobileDevices)
            {
                if (!string.IsNullOrEmpty(device.Value))
                {
                    if ((Request.UserAgent.IndexOf(device.Value, StringComparison.OrdinalIgnoreCase)) > 0)
                    {
                        ISMOBILE_DEVICE = true;
                        break;

                    }
                }

            }//end:foreach loop

            if (ISMOBILE_DEVICE)
            {
                HttpContext.Current.Response.Redirect("~/Views/Mobile/Home.aspx");
              //  Server.Transfer("~/Views/Mobile/Home.aspx");
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Views/Desktop/Home.aspx");
            //    Server.Transfer("~/Views/Desktop/Home.aspx");

            }
        }
    }
}