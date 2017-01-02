using System;

namespace GBT.Plugin.Core
{
    public static class TypeExtensions
    {
        public static T CreateInstance<T>(this Type type)
            where T : class
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}
