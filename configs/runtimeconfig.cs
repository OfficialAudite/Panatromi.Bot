using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.configs
{
    partial class runtimeconfig
    {
        // GENERAL SETTINGS
        public static readonly string version = "0.1.2.1";
        public static readonly string programmers = "Syx, bakk, Cobly, \nMartinho23";
        public static readonly string designers = "Twisted";
        public static readonly string language = "English";
        public static readonly string starteddevdate = "09-19-2018";
        public static readonly string donators = "NULL";
        public static readonly string ingame = "Under Developerment in C#";

        // PATHS
        public static readonly string actionspath = @"files\actions\";

        // OTHER
        public static readonly string favouritecolor = "144, 238, 144";

        //UPTIME
        public static DateTime StartTime { get; set; }
    }
}
