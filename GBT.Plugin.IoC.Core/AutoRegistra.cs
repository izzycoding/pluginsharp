using System.Linq;
using System.Reflection;
using GBT.Plugin.Core;

namespace GBT.Plugin.IoC.Core
{
    public static class AutoRegistra
    {
        public static void Configure(IContainer container)
        {
            Registra = container;
            PluginLoader.PluginLoaded += PluginHandler;
        }

        private static IContainer Registra { get; set; }

        private static void PluginHandler(object sender, PluginLoaderEventArgs e)
        {
            e.LoadedPluginTypes
                .Select(t => t.GetCustomAttribute<AutoRegisterAttribute>())
                .ToList()
                .ForEach(ActionRegistration);
        }

        private static void ActionRegistration(AutoRegisterAttribute attribute)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (attribute.RegistrationType)
            {
                case RegistrationType.Direct:
                    var registerMethod = Registra.GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .First(m => m.Name == "Register")
                        .MakeGenericMethod(attribute.Interface, attribute.Type);
                    registerMethod.Invoke(Registra, null);
                    break;
                case RegistrationType.Factory:
                    var registerFactoryMethod = Registra.GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .First(m => m.Name == "RegisterFactory")
                        .MakeGenericMethod(attribute.Interface);
                    registerFactoryMethod.Invoke(Registra, new object[] { attribute.FactoryFunc });
                    break;
            }
        }
    }
}
