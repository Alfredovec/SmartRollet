using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.BLL.Interfaces;
using SmartRollet.DAL.Interfaces;

namespace SmartRollet.BLL.Services
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IRolletService RolletService { get {return new RolletService(_unitOfWork);}}
    }
}
