using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRollet.BLL.Interfaces
{
    public interface IService
    {
        IRolletService RolletService { get; }
    }
}
