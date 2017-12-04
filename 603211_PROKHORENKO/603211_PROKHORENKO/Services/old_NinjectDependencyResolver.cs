using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using _603211_PROKHORENKO.DAL.Entities;
using _603211_PROKHORENKO.DAL.Interfaces;
using _603211_PROKHORENKO.DAL.Repositories;

namespace _603211_PROKHORENKO.Services
{
    public class NinjectDependencyresolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyresolver(IKernel krnl)
        {
            kernel = krnl;
            kernel.Bind<IRepository<Dish>>().To<FakeRepository>();
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