using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete.Config;
using BusinessLogic.Concrete.UserRepository;
using BusinessLogic.Models;

namespace BusinessLogic.Concrete
{
    [AutomapServiceBehavior]
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepositoryClient();
        }

        public UserBlo Get(string email)
        {
            var user = _userRepository.Get(email);
            var result = Mapper.Map<UserBlo>(user);

            return result;
        }

        public void Post(UserBlo userBlo)
        {
            var user = Mapper.Map<User>(userBlo);
            _userRepository.Post(user);
        }
    }
}
