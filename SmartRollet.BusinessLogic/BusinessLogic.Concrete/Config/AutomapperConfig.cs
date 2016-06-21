using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Concrete.RolletRepository;
using BusinessLogic.Concrete.UserRepository;
using BusinessLogic.Models;

namespace BusinessLogic.Concrete.Config
{
    internal static class AutomapperConfig
    {
        internal static void InitializeMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserBlo>().ReverseMap();
                cfg.CreateMap<Rollet, RolletBlo>().ReverseMap();
            });
        }
    }
}
