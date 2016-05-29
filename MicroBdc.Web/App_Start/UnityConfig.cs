using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MicroBdc.Domain;
using MicroBdc.Domain.Repositories.PlanBuilder;
using MicroBdc.Domain.UnitsOfWork;
using MicroBdc.Data.EntityFramework;
using MicroBdc.Data.EntityFramework.Repositories.PlanBuilder;
using MicroBdc.Data.EntityFramework.UnitsOfWork;
using MicroBdc.Web.Identity;
using Microsoft.AspNet.Identity;
using System;

namespace MicroBdc.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IAuthUnitOfWork, AuthUnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("Mvc5IdentityExample"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());
            container.RegisterType<ISectionUnitOfWork, SectionUnitOfWork>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}