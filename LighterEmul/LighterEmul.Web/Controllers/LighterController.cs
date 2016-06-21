using System.Linq;
using System.Web.Mvc;
using LighterEmul.Web.Static;

namespace LighterEmul.Web.Controllers
{
    public class LighterController : Controller
    {
        [HttpGet]
        public ActionResult Manage(int id)
        {
            var model = Database.Lighters.Single(l => l.Id == id);

            return View(model);
        }
    }
}
