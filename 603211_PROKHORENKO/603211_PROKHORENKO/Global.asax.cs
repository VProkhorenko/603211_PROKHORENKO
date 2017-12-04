using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using _603211_PROKHORENKO.DAL.Entities;
//using _603211_PROKHORENKO.DAL.Interfaces;
using Ninject;
using Ninject.Web.Common.WebHost;
using Ninject.Web.Mvc;
using _603211_PROKHORENKO.DAL.Entities;
using _603211_PROKHORENKO.DAL.Interfaces;
using _603211_PROKHORENKO.DAL.Repositories;
using _603211_PROKHORENKO.DAL.Services;

namespace _603211_PROKHORENKO
{
    public class MvcApplication : NinjectHttpApplication //System.Web.HttpApplication
    {
        protected override IKernel CreateKernel()
        {
            IKernel kernel =new StandardKernel();
            kernel.Bind<IRepository<Dish>>()
                .To<EFDishRepository>()
                .WithConstructorArgument("name", "FoodConnection");
            //DependencyResolver.SetResolver(new NinjectDependencyresolver(kernel));
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
