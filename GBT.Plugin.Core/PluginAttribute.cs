using System;
using System.Collections.Generic;

namespace GBT.Plugin.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : Attribute
    {
        public PluginAttribute(Type t)
        {
            foreach (var @interface in t.GetInterfaces())
            {
                if (!Plugins.ContainsKey(@interface.FullName))
                {
                    Plugins.Add(@interface.FullName, new List<Type>());
                }
                Plugins[@interface.FullName].Add(t);
            }
            Type = t;
        }

        public Type Type { get; }

        #region static members

        public static readonly Dictionary<string, List<Type>> Plugins = new Dictionary<string, List<Type>>();

        public static IEnumerable<Type> GetPlugins<T>() => GetPlugins(typeof(T));
        public static IEnumerable<Type> GetPlugins(Type type) => GetPlugins(type.FullName);
        public static IEnumerable<Type> GetPlugins(string typename)
        {
            return !Plugins.ContainsKey(typename) ? null : Plugins[typename];
        }

        #endregion
    }
}
