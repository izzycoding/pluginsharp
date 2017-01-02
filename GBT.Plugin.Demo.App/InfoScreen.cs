using System.Linq;
using System.Windows.Forms;
using GBT.Plugin.Core;
using GBT.Plugin.Demo.Core;
using static GBT.Plugin.Core.PluginAttribute;

namespace GBT.Plugin.DemoApp
{
    public partial class InfoScreen : Form
    {
        public InfoScreen()
        {
            InitializeComponent();

            // get registered types for each interface required
            var ones = GetPlugins(typeof(IThingyOne)).ToList();
            var twos = GetPlugins(typeof(IThingyTwo)).ToList();

            // ReSharper disable CoVariantArrayConversion
            lstOnes.Items.AddRange(ones.Select(x => x.FullName).ToArray());
            lstTwos.Items.AddRange(twos.Select(x => x.FullName).ToArray());
            lstOnesInstance.Items.AddRange(ones.Select(x => x.CreateInstance<IThingyOne>().Name).ToArray());
            lstTwosInstance.Items.AddRange(twos.Select(x => x.CreateInstance<IThingyTwo>().Description).ToArray());
            // ReSharper enable CoVariantArrayConversion
        }
    }
}
