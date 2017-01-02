using System;
using GBT.Plugin.Core.Tests.Requirements;
using NUnit.Framework;

namespace GBT.Plugin.Core.Tests
{
    [TestFixture]
    public class RegistrationTests
    {
        [Test]
        public static void Should_have_no_registered_classes()
        {
            Assert.That(PluginAttribute.GetPlugins<IFakePlugin>(), Is.Null);
        }

        [Test]
        public static void Should_not_register_any_classes()
        {
            PluginLoader.RegisterPlugins(
                AppDomain.CurrentDomain,
                "Fake.Plugin.*.dll",
                TestContext.CurrentContext.TestDirectory,
                TestContext.CurrentContext.WorkDirectory
                );

            Assert.That(PluginAttribute.GetPlugins<IFakePlugin>(), Is.Null);
        }

        [Test, Ignore("Currently Being Developed")]
        public static void Should_register_plugin_classes()
        {
            PluginLoader.RegisterPlugins(
                AppDomain.CurrentDomain,
                "Test.Plugin.*.dll",
                TestContext.CurrentContext.TestDirectory,
                TestContext.CurrentContext.WorkDirectory
                );

            Assert.That(PluginAttribute.GetPlugins<IFakePlugin>(), Is.Null);
        }
    }
}
