using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.configs;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace MyFirstBot
{
    public class General
    {
        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }

        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = "Request took " + ctx.Client.Ping + "ms",
                Title = "Pong",
                Color = new DiscordColor(220, 20, 60)
            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("info")]
        public async Task Info(CommandContext ctx)
        {
                string someDate = "09-19-2018";
                DateTime startDate = DateTime.Parse(someDate);
                DateTime now = DateTime.Now;
                TimeSpan elapsed = now.Subtract(startDate);
                double daysAgo = elapsed.TotalDays;

            string day = " day";
            if(daysAgo >= 1)
            {
                day = " day";
            }
            else
            {
                day = " days";
            }

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = "**`Developers:`** Syx, bakk, Cobly, and Martinho23 \n**`Designer:`** Twisted \n**`Language:`** English\n**`Developing Since:`** " + daysAgo.ToString("0") + day + " ago \n**`Version:`** " + config.version,
                Title = "Information",
                Color = new DiscordColor(144, 238, 144)
            };
            await ctx.RespondAsync("", embed: embed);
        }
    }
}