using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete.RolletRepository;
using BusinessLogic.Models;

namespace BusinessLogic.Concrete
{
    public class RolletManager : IRolletManager
    {
        private readonly IRolletRepository _rolletRepository;

        public RolletManager()
        {
            _rolletRepository = new RolletRepositoryClient();    
        }

        public RolletBlo GetRollet(int value)
        {
            var rollet = _rolletRepository.GetRollet();

            return new RolletBlo()
            {
                Id = rollet.Id,
                Height = rollet.Height,
                Width = rollet.Width
            };
        }
    }
}
