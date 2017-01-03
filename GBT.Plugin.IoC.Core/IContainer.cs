using System;
using System.Collections.Generic;

namespace GBT.Plugin.IoC.Core
{
    public interface IContainer
    {
        void Register<TI, TC>();
        void RegisterFactory<TI>(Func<IEnumerable<TI>, TI> factoryFunc);
    }
}
