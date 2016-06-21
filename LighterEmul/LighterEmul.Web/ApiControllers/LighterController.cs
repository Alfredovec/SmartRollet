using System;
using System.Linq;
using System.Web.Http;
using LighterEmul.Web.Models;
using LighterEmul.Web.Static;

namespace LighterEmul.Web.ApiControllers
{
    public class LighterController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var result = Database.Lighters.Single(l => l.Id == id);

            return Ok(result);
        }

        public IHttpActionResult Post([FromBody]Lighter lighter)
        {
            if (lighter.Id != 0)
            {
                throw new InvalidOperationException("Lighter id must be 0");
            }

            lighter.Id = Database.Lighters.Max(l => l.Id) + 1;
            Database.Lighters.Add(lighter);

            return Ok();
        }

        public IHttpActionResult Put([FromBody] Lighter lighter)
        {
            var model = Database.Lighters.Single(l => l.Id == lighter.Id);
            model.Value = lighter.Value;

            return Ok();
        }
    }
}
