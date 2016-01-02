using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartRollet.BLL.Interfaces;
using SmartRollet.BLL.RolletApi;
using SmartRollet.BLL.Services;
using SmartRollet.DomainModel.Entities;
using IRolletService = SmartRollet.BLL.RolletApi.IRolletService;

namespace SmartRollet.Web.Controllers
{
    public class RolletController : Controller
    {
        private readonly IRolletService _rolletService;
        private readonly IService _service;

        public RolletController(IService service)
        {
            _rolletService = new RolletServiceClient();
            _service = service;
        }

        public ActionResult Index()
        { 
            return Json(_service.RolletService.GetAll(), JsonRequestBehavior.AllowGet);
        }

    }
}
