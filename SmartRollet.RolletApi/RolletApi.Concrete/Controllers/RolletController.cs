using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RolletApi.Concrete.Models;
using RolletApi.Concrete.RolletManager;

namespace RolletApi.Concrete.Controllers
{
    public class RolletController : ApiController
    {
        private readonly IRolletManager _rolletManager;

        public RolletController()
        {
            _rolletManager = new RolletManagerClient();
        }

        // GET api/rollet
        [HttpGet]
        public RolletDto Get(int id)
        {
            var rollet = _rolletManager.GetRollet(id);

            return new RolletDto()
            {
                Id = rollet.Id,
                Height = rollet.Height,
                Width = rollet.Width,
                OpenedPart = rollet.OpenedPart
            };
        }

        [HttpPost]
        public HttpResponseMessage Post(RolletDto model)
        {
            var rollet = new RolletBlo()
            {
                Id = model.Id,
                Width = model.Width,
                Height = model.Height,
                OpenedPart = model.OpenedPart
            };

            _rolletManager.UpdateRollet(rollet);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}