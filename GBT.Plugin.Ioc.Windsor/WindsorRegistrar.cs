using Castle.Windsor;
using GBT.Plugin.IoC.Core;

namespace GBT.Plugin.Ioc.Windsor
{
    public static class WindsorRegistrar
    {
        public static void ConfigurePluginRegistration(this IWindsorContainer container)
        {
            AutoRegistrar.Configure(new WindsorContainerWrapper(container));
        }
    }
}
