using System.Collections.Generic;
using LighterEmul.Web.Models;

namespace LighterEmul.Web.Static
{
    public static class Database
    {
        static Database()
        {
            Lighters = new List<Lighter>
            {
                new Lighter { Id = 1, Value = 45 },
                new Lighter { Id = 2, Value = 93 }
            };
        }

        public static List<Lighter> Lighters { get; set; }
    }
}
