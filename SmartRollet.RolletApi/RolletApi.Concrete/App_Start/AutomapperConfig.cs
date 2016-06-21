using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RolletApi.Concrete.Models;
using RolletApi.Concrete.RolletManager;
using RolletApi.Concrete.UserManager;

namespace RolletApi.Concrete.App_Start
{
    internal static class AutomapperConfig
    {
        internal static void InitializeMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RolletBlo, RolletDto>().ReverseMap();
                cfg.CreateMap<UserBlo, UserDto>().ReverseMap();
            });
        }
    }
}
