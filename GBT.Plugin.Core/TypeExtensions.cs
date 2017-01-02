using System;

namespace GBT.Plugin.Core
{
    public static class TypeExtensions
    {
        public static T CreateInstance<T>(this Type type)
            where T : class
        {
            if (!typeof(T).IsAssignableFrom(type))
                throw new InvalidCastException($"Unable to assign type '{type.Name}' to '{typeof(T).Name}'");
            return (T)Activator.CreateInstance(type);
        }
    }
}
