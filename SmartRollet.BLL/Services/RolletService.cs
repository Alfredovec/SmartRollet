using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.BLL.Interfaces;
using SmartRollet.DAL.Interfaces;
using SmartRollet.DomainModel.Entities;

namespace SmartRollet.BLL.Services
{
    public class RolletService : IRolletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolletService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Rollet> GetAll()
        {
            return _unitOfWork.RolletRepository.Get().ToList();
        }
    }
}
