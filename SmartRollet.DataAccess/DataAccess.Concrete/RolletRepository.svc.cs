using System;
using System.Collections.Generic;
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
            return new Rollet() { Height = 0, Id = 1, Width = 100 };
        }
    }
}
