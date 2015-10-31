using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.DomainModel.Entities;

namespace SmartRollet.BLL.Interfaces
{
    public interface IRolletService
    {
        IEnumerable<Rollet> GetAll();
    }
}
