using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRollet.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRolletRepository RolletRepository { get; }

        void Save();
    }
}
