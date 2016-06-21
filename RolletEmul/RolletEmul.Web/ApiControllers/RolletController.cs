using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RolletEmul.Web.Models;
using RolletEmul.Web.Static;

namespace RolletEmul.Web.ApiControllers
{
    public class RolletController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var rollet = Database.Rollets.Single(r => r.Id == id);

            return Ok(rollet);
        }

        public IHttpActionResult Post([FromBody] Rollet rollet)
        {
            if (rollet.Id != 0)
            {
                throw new InvalidOperationException("Rollet id must be 0");
            }

            rollet.Id = Database.Rollets.Max(r => r.Id) + 1;
            Database.Rollets.Add(rollet);

            return Ok();
        }

        public IHttpActionResult Put([FromUri]int id, [FromUri]int change)
        {
            var rollet = Database.Rollets.Single(r => r.Id == id);
            rollet.OpenedPart -= change;

            return Ok();
        }
    }
}
