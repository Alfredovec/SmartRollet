using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.DomainModel.Entities;

namespace SmartRollet.DAL
{
    public class RolletContext : DbContext
    {
        public RolletContext() : base("RolletContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Rollet> Rollets { get; set; }
    }
}
