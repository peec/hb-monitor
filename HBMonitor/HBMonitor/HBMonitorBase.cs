using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Styx;
using Styx.Helpers;
using Styx.Plugins;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Styx.TreeSharp;
using Styx.Common.Helpers;
using Styx.CommonBot.Inventory;
using Styx.Plugins;


namespace HBMonitor
{
    public class HBMonitorBase : HBPlugin
    {



        private readonly WaitTimer _updateTimer = WaitTimer.ThirtySeconds;

        HBMonitorAPI api;

        HBMonitorBase () {
            api = new HBMonitorAPI();
        }

        public override void Pulse()
        {
            if (_updateTimer.IsFinished)
            {
                _updateTimer.Reset();

                api.SendData(new HBMonitorStatus());
            }
        }

        public override string Name { get { return "HB Monitor"; } }

        public override string Author { get { return "Peec"; } }

        public override Version Version { get { return new Version(1, 0, 0, 0); } }


        public override string ButtonText { get { return "Settings"; } }
        public override bool WantButton { get { return true; } }

        private FormSettings _configForm;
        public override void OnButtonPress()
        {
            if (_configForm == null || _configForm.IsDisposed || _configForm.Disposing)
            {
                _configForm = new FormSettings();
            }

            _configForm.Show();
        }

    }
}
