using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.DAL.Interfaces;
using SmartRollet.DomainModel.Entities;

namespace SmartRollet.DAL.Repositories
{
    public class RolletRepository : IRolletRepository
    {
        private readonly RolletContext _context;

        public RolletRepository(RolletContext context)
        {
            _context = context;
        }

        public IQueryable<Rollet> Get()
        {
            return _context.Rollets;
        }

        public void Create(Rollet entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Rollet entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Rollet entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
