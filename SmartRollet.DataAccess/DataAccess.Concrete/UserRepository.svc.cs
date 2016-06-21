using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Models.Entities;

namespace DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly RolletContext _rolletContext;

        public UserRepository()
        {
            _rolletContext = new RolletContext();
        }

        public User Get(string email)
        {
            var result = _rolletContext.Users.Single(u => u.Email == email);

            return result;
        }

        public void Post(User user)
        {
            _rolletContext.Entry(user).State = EntityState.Added;
            _rolletContext.SaveChanges();
        }
    }
}
