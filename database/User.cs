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
    class User
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int Money { get; set; }
        public int XP { get; set; }
        public int Admin { get; set; }
        public int Donation { get; set; }
        public int Donator { get; set; }
        public DateTime LastDailyClaim { get; set; }
    }
}
