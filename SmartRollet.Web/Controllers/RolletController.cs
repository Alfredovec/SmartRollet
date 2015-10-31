using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartRollet.BLL.Interfaces;
using SmartRollet.DomainModel.Entities;

namespace SmartRollet.Web.Controllers
{
    public class RolletController : Controller
    {
        private readonly IService _service;

        public RolletController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            IEnumerable<Rollet> json = _service.RolletService.GetAll(); 
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}
