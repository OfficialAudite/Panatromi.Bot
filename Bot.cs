using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DiscordBot.configs;
using DSharpPlus.Entities;

namespace MyFirstBot
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = config.token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            discord.MessageCreated += async e =>
            {
                await discord.UpdateStatusAsync(new DiscordGame("Under Developerment in C#"));
            };

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = config.prefix
            });

            //Commands List
            commands.RegisterCommands<General>();
            commands.RegisterCommands<Actions>();
            // ----------- 

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
