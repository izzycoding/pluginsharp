using System;

namespace GBT.Plugin.IoC.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AutoRegisterAttribute : Attribute
    {
        public Type Interface { get; }
        public Type Type { get; }
        public Func<object, object> FactoryFunc { get; }
        public InstanceType InstanceType { get; }
        public RegistrationType RegistrationType { get; }

        public AutoRegisterAttribute(Type @interface, Type @class, InstanceType instanceType = InstanceType.Singleton)
        {
            Interface = @interface;
            Type = @class;
            InstanceType = instanceType;
            RegistrationType = RegistrationType.Direct;
        }

        public AutoRegisterAttribute(Type @interface, Func<object, object> factoryFunc)
        {
            Interface = @interface;
            FactoryFunc = factoryFunc;
            RegistrationType = RegistrationType.Factory;
        }
    }
}
