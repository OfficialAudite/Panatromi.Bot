using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.configs;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json.Linq;

namespace MyFirstBot
{
    class Settings
    {

        [Group("settings")]
        [Aliases("set")]
        public class SettingsGroup
        {
            [RequireOwner]
            [Command("prefix")]
            [Description("-set prefix (prefix) to change prefix to your wanted one.")]
            public async Task TaskAsync(CommandContext ctx)
            {
                config.prefix = ctx.RawArgumentString;
                await ctx.RespondAsync($"Prefix has been changed to: " + ctx.RawArgumentString);
            }
        }
    }
}
