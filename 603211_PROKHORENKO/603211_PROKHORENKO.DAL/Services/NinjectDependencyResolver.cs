using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using _603211_PROKHORENKO.DAL.Entities;
using _603211_PROKHORENKO.DAL.Interfaces;
using _603211_PROKHORENKO.DAL.Repositories;

namespace _603211_PROKHORENKO.DAL.Services
{
    ////
    //private static void RegisterServices(IKernel kernel)
    //{
    //DependencyResolver.SetResolver(new NinjectDependencyresolver(kernel));
    //}
    ////


    public class NinjectDependencyresolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyresolver(IKernel krnl)
        {
            kernel = krnl;
            //kernel = new StandardKernel();
            //kernel.Bind<IRepository<Dish>>().To<FakeRepository>();
            //привязка к созданному реальному репозиторию:
            kernel
                .Bind<IRepository<Dish>>()
                .To<EFDishRepository>()
                .WithConstructorArgument("name", "FoodConnection");
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
