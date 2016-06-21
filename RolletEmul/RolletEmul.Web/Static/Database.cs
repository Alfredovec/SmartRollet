using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RolletEmul.Web.Models;

namespace RolletEmul.Web.Static
{
    internal static class Database
    {
        static Database()
        {
            Rollets = new List<Rollet>
            {
                new Rollet
                {
                    Id = 1,
                    OpenedPart = 10
                },
                new Rollet
                {
                    Id = 2,
                    OpenedPart = 25
                }
            };            
        }

        internal static List<Rollet> Rollets { get; set; } 
    }
}
