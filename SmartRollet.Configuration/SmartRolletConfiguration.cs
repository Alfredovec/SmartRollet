using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SmartRollet.BLL.Interfaces;
using SmartRollet.BLL.Services;
using SmartRollet.DAL;
using SmartRollet.DAL.Interfaces;

namespace SmartRollet.Configuration
{
    public class SmartRolletConfiguration
    {
        public static void RegisterInjection(IKernel kernel)
        {
            kernel.Bind<IService>().To<Service>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
