using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DiscordBot.configs;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace MyFirstBot
{
    public class Actions
    {
        private static readonly Random rand = new Random();

        [Command("fbi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " sends FBI on " + ctx.RawArgumentString,
                Title = "FBI OPEN UP!",
                ImageUrl = "https://media1.tenor.com/images/93d11bc59526ce49f60766f0045d819b/tenor.gif?itemid=11500735",
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        private Random random = new Random();

        [Command("kiss")]
        [Description("Kiss action, [prefix]kiss @user")]
        public async Task Kiss(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "kiss.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " kisses " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("bite")]
        [Description("Kiss action, [prefix]bite @user")]
        public async Task Bite(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "bite.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " bites " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("cuddle")]
        [Description("Cuddle action, [prefix]cuddle @user")]
        public async Task Cuddle(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "cuddle.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " cuddles with " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("hug")]
        [Description("Hug action, [prefix]hug @user")]
        public async Task Hug(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "hug.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " hugs " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("mad")]
        [Description("Mad action, [prefix]mad @user")]
        public async Task Mad(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "mad.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " is mad at " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("pat")]
        [Description("Pat action, [prefix]cuddle @user")]
        public async Task Pat(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "pat.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " pats " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("pout")]
        [Description("Pout action, [prefix]pout @user")]
        public async Task Pout(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "pout.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("punch")]
        [Description("Punch action, [prefix]punch @user")]
        public async Task Punch(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "punch.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " punches " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("slap")]
        [Description("Slap action, [prefix]slap @user")]
        public async Task Slap(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);
            string[] lines = File.ReadAllLines(runtimeconfig.actionspath + "slap.txt");
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " slaps " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("woah")]
        [Description("Slap action, [prefix]slap @user")]
        [Hidden]
        public async Task Woah(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                ImageUrl = "https://panatromi.leakoni.net/none1.gif",
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
            await ctx.Message.DeleteAsync();
        }

        [Command("life")]
        [Description("Life In Nutshell")]
        [Hidden]
        public async Task Life(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            byte myByte = (byte)rand.Next(0, 255);
            byte myByte2 = (byte)rand.Next(0, 255);
            byte myByte3 = (byte)rand.Next(0, 255);

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Title = "Life in a nutshell...",
                ImageUrl = "https://cdn.discordapp.com/attachments/456353024529399809/493876998649806849/none_Large.gif",
                Color = new DiscordColor(myByte, myByte2, myByte3)
            };

            await ctx.RespondAsync("", embed: embed);
            await ctx.Message.DeleteAsync();
        }
    }
}