using Castle.MicroKernel.Registration;
using GBT.Plugin.IoC.Core;

namespace GBT.Plugin.Ioc.Windsor
{
    public static class ComponentRegistrationExtensions
    {
        public static ComponentRegistration<TI> SetLifestyle<TI>(this ComponentRegistration<TI> comReg,
            InstanceType lifestyle) where TI : class
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (lifestyle)
            {
                case InstanceType.Transient:
                    comReg.LifestyleTransient();
                    break;
                case InstanceType.PerThread:
                    comReg.LifestylePerThread();
                    break;
                case InstanceType.PerWebRequest:
                    comReg.LifestylePerWebRequest();
                    break;
                case InstanceType.Pooled: // ToDo: implement this properly
                    comReg.LifestylePooled();
                    break;
                case InstanceType.Scoped: // ToDo: implement this properly
                    comReg.LifestyleScoped();
                    break;
                default: //InstanceType.Singleton
                    comReg.LifestyleSingleton();
                    break;
            }
            return comReg;
        }
    }
}
