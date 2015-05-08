using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;


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
            return "\""+t+"\"";
        }

        public void request(HBMonitorStatus status)
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

        public async Task SendData(HBMonitorStatus status)
        {
            request(status);
        }



    }
}
