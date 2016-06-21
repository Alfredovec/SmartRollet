using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SmartRollet.Web.Models;

namespace SmartRollet.Web.Controllers
{
    public class RolletController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            var httpClient = new HttpClient();

            if (!ClaimsPrincipal.Current.Identity.IsAuthenticated)
            {
                return View(new List<RolletViewModel>());
            }

            var user = ClaimsPrincipal.Current;
            var email = user.FindFirst("email").Value;

            var url = $"http://api.smart-rollet.com/Rollet?email={email}";
            var response = httpClient.GetAsync(url).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            var jsonSerializer = new JavaScriptSerializer();
            var rollets = jsonSerializer.Deserialize<IEnumerable<RolletViewModel>>(responseString);

            return View(rollets);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Manage(RolletViewModel model)
        {
            var httpClient = new HttpClient();

            var values = new Dictionary<string, string>
            {
                {"Id", model.Id.ToString() },
                {"Height", model.Height.ToString() },
                {"Width", model.Width.ToString() },
                {"RolletState", model.RolletState.ToString() }
            };

            var postContent = new FormUrlEncodedContent(values);

            var response = httpClient.PostAsync(@"http://api.smart-rollet.com/rollet/1", postContent).Result;
        }
    }
}
