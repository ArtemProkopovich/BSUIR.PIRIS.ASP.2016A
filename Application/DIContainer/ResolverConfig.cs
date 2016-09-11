using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BL.Interface;
using DAL;
using DAL.Interface;
using DAL.Interface.Entity;
using Ninject;
using Ninject.Web.Common;

namespace DIContainer
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IConfigurationManager>().To<ConfigurationManager>().InRequestScope();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();              
            }
            else
            {
                kernel.Bind<IConfigurationManager>().To<ConfigurationManager>().InSingletonScope();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            }
            #region services
            kernel.Bind<IClientService>().To<ClientService>();
            #endregion
            #region repositories 
            kernel.Bind<IRepository<Client>>().To<ClientRepository>();
            kernel.Bind<IRepository<Citizenship>>().To<CitizenshipRepository>();
            kernel.Bind<IRepository<Disability>>().To<DisabilityRepository>();
            kernel.Bind<IRepository<MartialStatus>>().To<MartialStatusRepository>();
            kernel.Bind<IRepository<Town>>().To<TownRepository>();
            #endregion
        }
    }
}
