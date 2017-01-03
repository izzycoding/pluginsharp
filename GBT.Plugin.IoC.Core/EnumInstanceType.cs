namespace GBT.Plugin.IoC.Core
{
    public enum InstanceType
    {
        Singleton
        , Transient
        , PerThread
        , PerWebRequest
        , Pooled
        , Scoped
    }
}
