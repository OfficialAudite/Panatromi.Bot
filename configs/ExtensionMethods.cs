using DSharpPlus.Entities;
using System;

namespace DiscordBot.configs
{
        public static class ExtensionMethods
        {
            public static string ToTimeString(this TimeSpan timeDifference)
            {
                string days = timeDifference.Days.ToString() + "D ";
                string hours = timeDifference.Hours.ToString() + "h ";
                string minutes = timeDifference.Minutes.ToString() + "min ";
                string seconds = timeDifference.Seconds.ToString() + "s";

                if (days == "0D ") days = "";
                if (hours == "0h ") hours = "";
                if (minutes == "0min ") minutes = "";

                return days + hours + minutes;
            }
        }
}
