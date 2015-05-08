using System;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using Styx.Helpers;
using Styx;

using DefaultValue = Styx.Helpers.DefaultValueAttribute;


namespace HBMonitor
{ 
    public class HBMonitorSettings : Settings
    {

        public static readonly HBMonitorSettings Instance = new HBMonitorSettings();
        public HBMonitorSettings()
            : base(Path.Combine(Path.Combine(Path.Combine(Path.Combine(Path.Combine(Styx.Common.Utilities.AssemblyDirectory, "Settings"), StyxWoW.Me.RealmName), StyxWoW.Me.Name), "GladRogue"), "Settings.xml"))
        {
        }



        [Setting]
        [DefaultValue("")]
        [Category("Authentication")]
        [DisplayName("Communication Code")]
        [Description("Your Communication Code, it identifies your character anonymously. Visit hbmonitor.pkj.no to get one!")]
        public string AuthSecret { get; set; }



        [Setting]
        [DefaultValue("http://hbmonitor.pkj.no/collect")]
        [Category("Developer")]
        [DisplayName("Backend Host")]
        [Description("For developers only. DO NOT EDIT.")]
        public string Backend { get; set; }


    }

}
