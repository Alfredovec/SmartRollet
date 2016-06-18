using System.Collections.Generic;
using System.Net.Http;
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

      var response = httpClient.GetAsync(@"http://api.smart-rollet.com/rollet/1").Result;

      var responseString = response.Content.ReadAsStringAsync().Result;

      var jsonSerializer = new JavaScriptSerializer();
      var rollet = jsonSerializer.Deserialize<RolletViewModel>(responseString);

      return View(rollet);
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
                {"OpenedPart", model.OpenedPart.ToString() }
            };

      var postContent = new FormUrlEncodedContent(values);

      var response = httpClient.PostAsync(@"http://api.smart-rollet.com/rollet/1", postContent).Result;
    }
  }
}
