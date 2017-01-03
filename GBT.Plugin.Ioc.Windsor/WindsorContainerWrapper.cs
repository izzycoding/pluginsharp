using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GBT.Plugin.IoC.Core;
using GBT.Plugin.Core;

namespace GBT.Plugin.Ioc.Windsor
{
    public class WindsorContainerWrapper : IContainer
    {
        private readonly IWindsorContainer _parentContainer;

        public WindsorContainerWrapper(IWindsorContainer container)
        {
            _parentContainer = container;
        }

        public void Register<TI, TC>(InstanceType lifestyle = InstanceType.Singleton)
            where TI : class
            where TC : TI
        {
            _parentContainer.Register(Component.For<TI>().ImplementedBy<TC>().SetLifestyle(lifestyle));
        }

        public void RegisterFactory<TI>(Func<IEnumerable<Type>, Type> factoryFunc)
            where TI : class
        {
            _parentContainer.Register(Component.For<TI>().UsingFactoryMethod(() => factoryFunc(PluginAttribute.GetPlugins<TI>()).CreateInstance<TI>()));
        }
    }
}
