using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartRollet.Web.ApiControllers
{
    public class RolletController : ApiController
    {
        public IHttpActionResult Put([FromUri]int id, [FromUri]int change)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"http://api.smart-rollet.com/rollet/{id}?change={change}";
                var response = httpClient.PutAsync(url, null).Result;
                response.EnsureSuccessStatusCode();
            }

            return Ok();
        }
    }
}
