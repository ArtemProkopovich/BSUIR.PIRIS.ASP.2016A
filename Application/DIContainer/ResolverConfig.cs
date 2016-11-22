using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Web.Common;
using AppContext = ORMLibrary.AppContext;

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
                kernel.Bind<AppContext>().To<AppContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<AppContext>().To<AppContext>().InSingletonScope();
            }

            #region services
            #endregion

            #region repositories 
            #endregion


        }
    }
}
