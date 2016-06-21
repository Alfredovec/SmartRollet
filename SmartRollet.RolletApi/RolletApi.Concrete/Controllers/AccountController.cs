using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using RolletApi.Concrete.Models;
using RolletApi.Concrete.UserManager;

namespace RolletApi.Concrete.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserManagerClient _userManager;

        public AccountController()
        {
            _userManager = new UserManagerClient();    
        }

        public UserDto Get(string email)
        {
            var userBlo = _userManager.Get(email);
            var model = Mapper.Map<UserDto>(userBlo);

            return model;
        }

        public HttpResponseMessage Post(string email)
        {
            _userManager.Post(new UserBlo { Email = email });

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
