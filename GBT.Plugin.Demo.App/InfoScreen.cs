using System;
using System.Linq;
using System.Windows.Forms;
using GBT.Plugin.Core;
using GBT.Plugin.Demo.Core;

namespace GBT.Plugin.Demo.App
{
    public partial class InfoScreen : Form
    {
        public InfoScreen()
        {
            InitializeComponent();
            RefreshPluginLists();
        }

        private void RefreshPluginLists()
        {
            // empty lists ready for new listing input
            lstOnes.Items.Clear();
            lstTwos.Items.Clear();
            lstOnesInstance.Items.Clear();
            lstTwosInstance.Items.Clear();

            // get registered types for each interface required
            var ones = PluginAttribute.GetPlugins(typeof(IThingyOne)).ToList();
            var twos = PluginAttribute.GetPlugins(typeof(IThingyTwo)).ToList();

            // ReSharper disable CoVariantArrayConversion
            lstOnes.Items.AddRange(ones.Select(x => x.FullName).OrderBy(x => x).ToArray());
            lstTwos.Items.AddRange(twos.Select(x => x.FullName).OrderBy(x => x).ToArray());
            lstOnesInstance.Items.AddRange(ones.Select(x => x.CreateInstance<IThingyOne>().Name).OrderBy(x => x).ToArray());
            lstTwosInstance.Items.AddRange(twos.Select(x => x.CreateInstance<IThingyTwo>().Description).OrderBy(x => x).ToArray());
            // ReSharper enable CoVariantArrayConversion
        }
    }
}
