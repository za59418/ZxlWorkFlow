using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Business.Model;

namespace Zxl.WebSite
{
    public class UnityConfig
    {
        public static UnityContainer container = null;
        public static void RegisterTypes()
        {
            UnityConfig.container = new UnityContainer();
            UnityConfigurationSection unityConfigurationSection = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            bool flag = unityConfigurationSection == null;
            if (flag)
            {
                throw new ConfigurationErrorsException("Web.Config没有找到Unity配置!");
            }
            foreach (ContainerElement current in unityConfigurationSection.Containers)
            {
                unityConfigurationSection.Configure(UnityConfig.container, current.Name);
            }
            Microsoft.Practices.Unity.UnityContainerExtensions.RegisterType<IControllerFactory, UnityControllerFactory>(UnityConfig.container, new InjectionMember[0]);
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.container));
        }
        public static T GetObject<T>()
        {
            return Microsoft.Practices.Unity.UnityContainerExtensions.Resolve<T>(UnityConfig.container, new ResolverOverride[0]);
        }

    }

    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer container;

        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext reqContext, Type controllerType)
        {
            IController result;
            try
            {
                bool flag = controllerType != null;
                if (flag)
                {
                    result = (Microsoft.Practices.Unity.UnityContainerExtensions.Resolve(this.container, controllerType, new ResolverOverride[0]) as IController);
                    return result;
                }
            }
            catch (Exception e)
            {
            }
            result = null;
            return result;
        }
    }

    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            bool flag = !Microsoft.Practices.Unity.UnityContainerExtensions.IsRegistered(this.container, serviceType);
            object result;
            if (flag)
            {
                result = null;
            }
            else
            {
                result = Microsoft.Practices.Unity.UnityContainerExtensions.Resolve(this.container, serviceType, new ResolverOverride[0]);
            }
            return result;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType, new ResolverOverride[0]);
        }
    }
}
