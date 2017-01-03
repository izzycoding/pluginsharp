using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GBT.Plugin.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : Attribute
    {
        public PluginAttribute(Type t)
        {
            RegisterInterfaces(t, t);
            RegisterBaseInterfaces(t, t);
            RegisterInterface(t.FullName, t);
            Type = t;
        }

        public Type Type { get; }

        #region regestration methods

        private static void RegisterInterfaces(Type @base, Type type)
        {
            foreach (var @interface in @base.GetInterfaces())
            {
                RegisterInterface(@interface.FullName, type);
                RegisterBaseInterfaces(@interface, type);
            }
        }

        private static void RegisterInterface(string interfaceName, Type type)
        {
            if (!Plugins.ContainsKey(interfaceName))
            {
                while (!Plugins.TryAdd(interfaceName, new ConcurrentBag<Type>())) { }
            }
            if (!Plugins[interfaceName].Contains(type))
            {
                Plugins[interfaceName].Add(type);
            }
        }

        private static void RegisterBaseInterfaces(Type parent, Type type)
        {
            while (true)
            {
                var @base = parent.BaseType;
                if (@base == null) return;
                RegisterInterfaces(@base, type);

                parent = @base;
            }
        }

        #endregion

        #region static members

        public static readonly ConcurrentDictionary<string, ConcurrentBag<Type>> Plugins = new ConcurrentDictionary<string, ConcurrentBag<Type>>();

        public static IEnumerable<Type> GetPlugins<T>() => GetPlugins(typeof(T));
        public static IEnumerable<Type> GetPlugins(Type type) => GetPlugins(type.FullName);
        public static IEnumerable<Type> GetPlugins(string typename)
        {
            return !Plugins.ContainsKey(typename) ? null : Plugins[typename];
        }

        #endregion
    }
}
