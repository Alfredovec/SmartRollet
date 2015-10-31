using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.DAL.Interfaces;
using SmartRollet.DAL.Repositories;

namespace SmartRollet.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RolletContext _context;

        public UnitOfWork()
        {
            _context = new RolletContext();
        }

        public IRolletRepository RolletRepository { get { return new RolletRepository(_context);} }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
