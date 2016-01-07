using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Models;

namespace DataAccess.Concrete
{
    public class RolletRepository : IRolletRepository
    {
        private readonly RolletContext _rolletContext;

        public RolletRepository()
        {
            _rolletContext = new RolletContext();
        }

        public Rollet GetRollet()
        {
            var rollet = _rolletContext.Rollets.First();
            return rollet;
        }

        public void UpdateRollet(Rollet rollet)
        {
            _rolletContext.Entry(rollet).State = EntityState.Modified;
            _rolletContext.SaveChanges();
        }
    }
}
