using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMonitor
{
    public class HBMonitorStatus
    {
        
        
        public string AuthSecret {
            get
            {
                return HBMonitorSettings.Instance.AuthSecret;
            }
        }


        public bool IsRunning
        {
            get
            {
                return Styx.CommonBot.TreeRoot.IsRunning;
            }
        }


        public string GoalText
        {
            get
            {
                return Styx.CommonBot.TreeRoot.GoalText;
            }
        }


        public string StatusText
        {
            get
            {
                return Styx.CommonBot.TreeRoot.StatusText;
            }
        }




    }
}
