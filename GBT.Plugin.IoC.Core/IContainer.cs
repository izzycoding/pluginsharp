using System;
using System.Collections.Generic;

namespace GBT.Plugin.IoC.Core
{
    public interface IContainer
    {
        void Register<TI, TC>(InstanceType lifestyle = InstanceType.Singleton)
            where TI : class
            where TC : TI;
        void RegisterFactory<TI>(Func<IEnumerable<Type>, Type> factoryFunc)
            where TI : class;
    }
}
