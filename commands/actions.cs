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
        private Random random = new Random();

        [Command("kiss")]
        public async Task Kiss(CommandContext ctx)
        {
            string[] lines = File.ReadAllLines(config.path);
            int lineCount = lines.Length;
            int randomLineNumber = random.Next(0, lineCount);
            string link = lines[randomLineNumber];

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " kisses " + ctx.RawArgumentString,
                ImageUrl = link,
                Color = new DiscordColor(0, 191, 255)
            };

            await ctx.RespondAsync("", embed: embed);
        }

        [Command("fbi")]
        public async Task Hi(CommandContext ctx)
        {
            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Description = ctx.User.Mention + " sends FBI on " + ctx.RawArgumentString,
                Title = "FBI OPEN UP!",
                ImageUrl = "https://media1.tenor.com/images/93d11bc59526ce49f60766f0045d819b/tenor.gif?itemid=11500735",
                Color = new DiscordColor(220, 20, 60)
            };

            await ctx.RespondAsync("", embed: embed);
        }
    }
}