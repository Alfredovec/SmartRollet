using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
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
        
        [HttpGet]
        public IHttpActionResult Get(string email)
        {
            var rollets = _rolletManager.GetRollets(email);
            var result = Mapper.Map<IEnumerable<RolletDto>>(rollets);

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(RolletDto model)
        {
            var rolletBlo = Mapper.Map<RolletBlo>(model);
            _rolletManager.UpdateRollet(rolletBlo);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromUri]int change)
        {
            _rolletManager.ChangePosition(id, change);

            return Ok();
        }
    }
}