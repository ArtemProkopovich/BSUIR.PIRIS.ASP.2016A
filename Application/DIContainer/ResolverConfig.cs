using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Web.Common;
using ORMLibrary;

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
                kernel.Bind<DatabaseContext>().To<DatabaseContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<DatabaseContext>().To<DatabaseContext>().InSingletonScope();
            }

            #region services
            #endregion

            #region repositories 
            #endregion


        }
    }
}
