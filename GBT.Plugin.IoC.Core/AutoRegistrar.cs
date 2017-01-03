using System.Linq;
using System.Reflection;
using GBT.Plugin.Core;

namespace GBT.Plugin.IoC.Core
{
    public static class AutoRegistrar
    {
        public static void Configure(IContainer container)
        {
            Registrar = container;
            PluginLoader.PluginLoaded += PluginHandler;
        }

        private static IContainer Registrar { get; set; }

        private static void PluginHandler(object sender, PluginLoaderEventArgs e)
        {
            e.LoadedPluginTypes
                .SelectMany(t => t.GetCustomAttributes<AutoRegisterAttribute>())
                .ToList()
                .ForEach(ActionRegistration);
        }

        private static void ActionRegistration(AutoRegisterAttribute attribute)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (attribute.RegistrationType)
            {
                case RegistrationType.Direct:
                    var registerMethod = Registrar.GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .First(m => m.Name == "Register")
                        .MakeGenericMethod(attribute.Interface, attribute.Type);
                    registerMethod.Invoke(Registrar, new object[] { attribute.InstanceType });
                    break;
                case RegistrationType.Factory:
                    var registerFactoryMethod = Registrar.GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .First(m => m.Name == "RegisterFactory")
                        .MakeGenericMethod(attribute.Interface);
                    registerFactoryMethod.Invoke(Registrar, new object[] { attribute.FactoryFunc });
                    break;
            }
        }
    }
}
