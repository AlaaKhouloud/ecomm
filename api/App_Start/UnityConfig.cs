using api.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterSingleton<IService, ServiceImpl>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}