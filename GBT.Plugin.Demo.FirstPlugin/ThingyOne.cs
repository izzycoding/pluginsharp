using GBT.Plugin.Core;
using GBT.Plugin.Demo.Core;

namespace GBT.Plugin.Demo.FirstPlugin
{
    [Plugin(typeof(ThingyOne))]
    public class ThingyOne : IThingyOne
    {
        public string Name { get; set; } = "First Thingy";
    }
}
