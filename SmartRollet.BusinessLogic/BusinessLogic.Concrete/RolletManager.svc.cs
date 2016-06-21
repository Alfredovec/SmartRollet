using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete.Config;
using BusinessLogic.Concrete.RolletRepository;
using BusinessLogic.Models;

namespace BusinessLogic.Concrete
{
    [AutomapServiceBehavior]
    public class RolletManager : IRolletManager
    {
        private readonly IRolletRepository _rolletRepository;

        public RolletManager()
        {
            _rolletRepository = new RolletRepositoryClient();    
        }

        public IEnumerable<RolletBlo> GetRollets(string email)
        {
            var rollets = _rolletRepository.GetRollets(email);
            return Mapper.Map<IEnumerable<RolletBlo>>(rollets);
        }

        public void UpdateRollet(RolletBlo rolletBlo)
        {
            var rollet = Mapper.Map<Rollet>(rolletBlo);
            _rolletRepository.UpdateRollet(rollet);
        }

        public void ChangePosition(int id, int change)
        {
            _rolletRepository.ChangePosition(id, change);
        }
    }
}
