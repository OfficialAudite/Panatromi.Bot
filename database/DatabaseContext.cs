using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DiscordBot.configs;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyFirstBot
{
    class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost;Database=panatromi;User=root;Password=root;");
        }
    }
}
