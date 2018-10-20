using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DiscordBot.configs;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Pomelo.EntityFrameworkCore;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Text.RegularExpressions;

namespace MyFirstBot
{
    class Economy
    {
        private static readonly Random rand = new Random();
        public DiscordColor ColorGenerator()
        {
            byte r = (byte)rand.Next(0, 255);
            byte g = (byte)rand.Next(0, 255);
            byte b = (byte)rand.Next(0, 255);
            return new DiscordColor(r, g, b);
        }


        string footer = " ";

        public void AddUser(string userId, int money = 100)
        {
            using (var db = new DatabaseContext())
            {
                var user = new User
                {
                    UserID = userId,
                    Money = 100,
                    XP = 0,
                    Donation = 0,
                    Donator = 0,
                    Admin = 0,
                    LastDailyClaim = DateTime.Now - TimeSpan.FromDays(1)
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public async Task profile(CommandContext ctx)
        {

            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == ctx.User.Id.ToString());
                if (result != null)
                {

                    if (result.Admin == 1) { footer = "Certified Panatromi Developer"; }
                    else { footer = " "; }

                    if (result.Donator == 1) { footer = "Certified Panatromi Donator"; }
                    else if (result.Admin == 1) { footer = "Certified Panatromi Developer"; }
                    else { footer = " "; }

                    var embed = new DiscordEmbedBuilder()
                    .WithColor(new DiscordColor(0xCEBD1))
                    .WithFooter(footer, null)
                    .WithThumbnailUrl(ctx.User.AvatarUrl)
                    .WithAuthor("" + ctx.User.Username + "'s Profile")
                    .AddField("Information", "XP: " + result.XP + "\nReputation: 0\n", false)
                    .AddField("Panacredits", +result.Money + " 💶", false)
                    .AddField("Extra", "Achivements: Coming Soon", false);

                    await ctx.RespondAsync(null, false, embed);
                }
                else
                {
                    AddUser(ctx.User.Id.ToString());
                }
            }
        }

        [Command("daily")]
        [Description("Get your daily credits.")]
        public async Task Daily(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == ctx.User.Id.ToString());

                if (result == null)
                {
                    AddUser(ctx.User.Id.ToString());
                    await Daily(ctx);
                }

                else if ((DateTime.Now - result.LastDailyClaim).Hours > 12 && result != null)
                {

                    DiscordEmbed embed = new DiscordEmbedBuilder()
                    {
                        Title = "💶 Panacredits",
                        Description = ctx.User.Username + ", **500** credits added to your account!",
                        Color = ColorGenerator()
                    };

                    result.LastDailyClaim = DateTime.Now;
                    result.Money += 500;
                    db.SaveChanges();
                    await ctx.RespondAsync("", embed: embed);
                }

                else if ((DateTime.Now - result.LastDailyClaim).Hours < 12 && result != null)
                {

                    DiscordEmbed embed2 = new DiscordEmbedBuilder()
                    {
                        Title = "💶 Panacredits",
                        Description = ctx.User.Username + ", you have to wait **" + (TimeSpan.FromHours(12) - (DateTime.Now - result.LastDailyClaim)).ToTimeString() + "** to claim again!",
                        Color = ColorGenerator()
                    };

                    await ctx.RespondAsync("", embed: embed2);
                }

            }

            await ctx.RespondAsync("");
        }

        [Command("profile")]
        [Description("This is where you find your profile.")]
        public async Task Profile(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == ctx.User.Id.ToString());

                if (result == null)
                {
                    AddUser(ctx.User.Id.ToString());
                    await Profile(ctx);
                }
                else if (result != null)
                {
                    await profile(ctx);
                }
            }
        }

        [Command("balance")]
        [Aliases("bal")]
        [Description("You can simply check your balance.")]
        public async Task Balance(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == ctx.User.Id.ToString());

                if (result == null)
                {
                    AddUser(ctx.User.Id.ToString());
                    await Balance(ctx);
                }

                else if (result != null)
                {

                    DiscordEmbed embed3 = new DiscordEmbedBuilder()
                    {
                        Title = "💶 Panacredits",
                        Description = ctx.User.Username + ", you have **" + result.Money + "** credits!",
                        Color = ColorGenerator()
                    };

                    await ctx.RespondAsync("", embed: embed3);
                }
            }

        }

        [Command("set")]
        [Description("Sets money! Owner Only!")]
        [Hidden]
        [RequireOwner]
        public async Task SetBalance(CommandContext ctx, string user, string amount)
        {
            await ctx.TriggerTypingAsync();

            string user2 = new Regex("\\d+").Match(user).Value;

            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == user2);
                {
                    DiscordEmbed embed4 = new DiscordEmbedBuilder()
                    {
                        Title = "💶 Panacredits",
                        Description = user + ", credits have been set to **" + amount + "**",
                        Color = ColorGenerator()
                    };

                    result.Money = int.Parse(amount);
                    db.SaveChanges();
                    await ctx.RespondAsync("", embed: embed4);
                }

            }

            await ctx.RespondAsync("");
        }

        [Command("give")]
        [Description("<user> <amount>, transfer your money to a friend!")]
        public async Task TransferMoney(CommandContext ctx, [Description("@user, simply tag user")] string user, [Description("amount that you want to give")] string amount)
        {
            await ctx.TriggerTypingAsync();

            bool takeMoneyResult = TakeMoney(ctx.User.Id.ToString(), int.Parse(amount));
            if (takeMoneyResult)
            {
                DiscordEmbed embed4 = new DiscordEmbedBuilder()
                {
                    Title = "💶 Panacredits",
                    Description = "**" + amount.ToString() + "** credits were successfully transfered to **" + user + "**",
                    Color = ColorGenerator()
                };

                GiveMoney(user, int.Parse(amount));
                await ctx.RespondAsync("", embed: embed4);
            }
            else
            {
                DiscordEmbed embed4 = new DiscordEmbedBuilder()
                {
                    Title = "💶 Panacredits",
                    Description = "Failed to transfer the money. Are you sure you have enough?",
                    Color = ColorGenerator()
                };

                await ctx.RespondAsync("", embed: embed4);
            }

            await ctx.RespondAsync("");
        }

        public void GiveMoney(string user, int amount)
        {
            user = new Regex("\\d+").Match(user).Value;

            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == user);
                if (result != null)
                {
                    result.Money += amount;
                    db.SaveChanges();
                }
                else
                {
                    AddUser(user);
                    GiveMoney(user, amount);
                }
            }
        }

        public bool TakeMoney(string user, int amount)
        {
            user = new Regex("\\d+").Match(user).Value;

            using (var db = new DatabaseContext())
            {
                var result = db.Users.SingleOrDefault(b => b.UserID == user);
                if (result != null)
                {
                    if (result.Money >= amount && amount > 0)
                    {
                        result.Money -= amount;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    db.SaveChanges();
                }
                else
                {
                    AddUser(user);
                    TakeMoney(user, amount);
                }
            }

            return true;
        }

        [Command("coinflip")]
        [Aliases("cf")]
        [Description("<h/t> <amount>, flip the coin and see if you got it right.")]
        public async Task CoinFlip(CommandContext ctx, string face, string amount)
        {

            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Title = "💶 Coin Flip",
                ImageUrl = "http://backup.leakoni.net/844WOLwn2Gyavl0/spin.gif",
                Color = ColorGenerator()
            };

            var message = await ctx.RespondAsync("", embed: embed);
            string title = "You lost.";

            int randomNum = new Random().Next(1, 5000);
            if (randomNum == 2500)
            {
                GiveMoney(ctx.User.Id.ToString(), int.Parse(amount) * 50);

                var resultEmbed = new DiscordEmbedBuilder()
                {
                    Title = "Side! Your bet will be multiplied by 50",
                    ImageUrl = "http://backup.leakoni.net/844WOLwn2Gyavl0/spin.gif",
                    Color = ColorGenerator()
                };
      
        message.ModifyAsync((Optional<DiscordEmbed>)resultEmbed);
            }
            else if (randomNum < 2500)
            {
                if (face == "h")
                {
                    title = "You win!";
                  GiveMoney(ctx.User.Id.ToString(), int.Parse(amount) * 2);
                }

                var resultEmbed = new DiscordEmbedBuilder()
                {
                    Title = "Heads! " + title,
                    ImageUrl = "link",
                    Color = ColorGenerator()
                };
      
                message.ModifyAsync(resultEmbed);
                    }
                else
                {
                if (face == "t")
                {
                  title = "You win!";
                  GiveMoney(ctx.User.Id.ToString(), int.Parse(amount) * 2);
                }

                var resultEmbed = new DiscordEmbedBuilder()
                {
                    Title = "Tails! " + title,
                    ImageUrl = "link",
                    Color = ColorGenerator()
                };
      
        message.ModifyAsync(resultEmbed);
            }
        }


    }
}