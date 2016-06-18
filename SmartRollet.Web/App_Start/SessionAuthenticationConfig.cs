using System;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SmartRollet.Web.App_Start.SessionAuthenticationConfig), "PreAppStart")]

namespace SmartRollet.Web.App_Start
{
    public static class SessionAuthenticationConfig
    {
        public static void PreAppStart()
        {
            DynamicModuleUtility.RegisterModule(typeof(System.IdentityModel.Services.SessionAuthenticationModule));
        }
    }
}