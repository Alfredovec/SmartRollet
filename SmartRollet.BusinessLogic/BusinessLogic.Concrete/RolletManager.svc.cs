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

        public RolletBlo GetRollet(int id)
        {
            var rollet = _rolletRepository.GetRollet();

            return new RolletBlo()
            {
                Id = rollet.Id,
                Height = rollet.Height,
                Width = rollet.Width,
                OpenedPart = rollet.OpenedPart
            };
        }

        public void UpdateRollet(RolletBlo rolletBlo)
        {
            var rollet = new Rollet()
            {
                Id = rolletBlo.Id,
                Height = rolletBlo.Height,
                Width = rolletBlo.Width,
                OpenedPart = rolletBlo.OpenedPart
            };

            _rolletRepository.UpdateRollet(rollet);
        }
    }
}
