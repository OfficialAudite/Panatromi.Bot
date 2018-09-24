using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.configs;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace MyFirstBot
{
    public class General
    {
        private static readonly Random rand = new Random();
        private Random random = new Random();

        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }

        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);

            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "ping.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            var emoji = DiscordEmoji.FromName(ctx.Client, ":ping_pong:");

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Title = "Pong " + emoji,
                Description = "Request took " + ctx.Client.Ping + "ms",
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };
            await ctx.RespondAsync("", embed: embed);
        }

        [RequireOwner]
        [Command("old-info")]
        [Hidden]
        public async Task OldInfo(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            string someDate = runtimeconfig.starteddevdate;
            DateTime startDate = DateTime.Parse(someDate);
            DateTime now = DateTime.Now;
            TimeSpan elapsed = now.Subtract(startDate);
            double daysAgo = elapsed.TotalDays;

            string day = " day";
            if (daysAgo > 1) day += "s";

            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = "**`Developers:`** " + runtimeconfig.programmers + "\n**`Designers:`** " + runtimeconfig.designers + "\n**`Language:`** " + runtimeconfig.language + "\n**`Developing Since:`** " + daysAgo.ToString("0") + day + " ago \n**`Version:`** " + runtimeconfig.version,
                Title = "Information",
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("info")]
        public async Task Info(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            string someDate = runtimeconfig.starteddevdate;
            DateTime startDate = DateTime.Parse(someDate);
            DateTime now = DateTime.Now;
            TimeSpan elapsed = now.Subtract(startDate);
            double daysAgo = elapsed.TotalDays;

            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);

            var embed = new DiscordEmbedBuilder();
            embed.AddField("Versions", $"Bot: {runtimeconfig.version}\n" + "DSharp+: 3.2.3", true);
            embed.AddField("Language", $"{runtimeconfig.language}", true);
            embed.AddField("Donators", $"{runtimeconfig.donators}\n\n", true);
            embed.AddField("Developers:", $"{runtimeconfig.programmers}", true);
            embed.AddField("Designers:", $"{runtimeconfig.designers}", true);
            embed.AddField("In dev since:", $"{daysAgo.ToString("0")} days ago", true);
            embed.Color = new DiscordColor(myByte, myByte2, myByte3);

            await ctx.RespondAsync("", embed: embed.Build());
        }

        [Command("ServerStats")]
        [Description("Bot Statistics Command")]
        public async Task ServerStats(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            var embed = new DiscordEmbedBuilder();
            embed.AddField("Server Name", ctx.Guild.Name);
            embed.AddField("Server Owner", $"Name: {ctx.Guild.Owner}\n");
            embed.AddField("Users", $"{ctx.Guild.MemberCount}\n");
            embed.AddField("Channels", $"{ctx.Guild.Channels.Count}\n");
            embed.Color = new DiscordColor(myByte, myByte2, myByte3);
            await ctx.RespondAsync(string.Empty, false, embed.Build());
        }

        [Command("math")]
        [Description("does the math for you")]
        public async Task Maths(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            double result = Convert.ToDouble(new DataTable().Compute(ctx.RawArgumentString, null));
            DiscordMessage botMessage = await ctx.RespondAsync(result.ToString());
            await Task.Delay(5000);
            await ctx.Message.DeleteAsync();
            await botMessage.DeleteAsync();

        }

        [Command("uptime")]
        [Description("Bot uptime")]
        public async Task Uptime(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);

            TimeSpan timeDifference = DateTime.Now - runtimeconfig.StartTime; 
            string days           = timeDifference.Days.ToString() + " Days ";
            string hours        = timeDifference.Hours.ToString() + " Hours ";
            string minutes  = timeDifference.Minutes.ToString() + " Minutes ";
            string seconds   = timeDifference.Seconds.ToString() + " Seconds";

            if (days == "0 Days ") days = "";
            if (hours == "0 Hours ") hours = "";
            if (minutes == "0 Minutes ") minutes = "";

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Title = "Uptime",
                Description = days + hours + minutes + seconds,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };
            await ctx.RespondAsync("", embed: embed);

        }

    }
}


