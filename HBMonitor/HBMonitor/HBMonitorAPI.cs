using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;


namespace HBMonitor
{


    public class HBMonitorAPI
    {


        public HBMonitorAPI()
        {

        }

        public string tf(bool t)
        {
            return t ? "true" : "false";
        }

        public string str(string t)
        {
            if (t != null)
            {
                t = Regex.Replace(t, "[^a-zA-Z0-9% ._,]", string.Empty);
            }
            return "\""+t+"\"";
        }

        public void request(HBMonitorStatus status)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(HBMonitorSettings.Instance.Backend);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"auth_secret\": " + str(status.AuthSecret) + ", \"is_running\": " + tf(status.IsRunning) + ", \"goal_text\": " + str(status.GoalText) + ", \"status_text\": " + str(status.StatusText) + "}";

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Styx.Common.Logging.Write(e.Message);
            }
        }

        public async Task SendData(HBMonitorStatus status)
        {
            request(status);
        }



    }
}
