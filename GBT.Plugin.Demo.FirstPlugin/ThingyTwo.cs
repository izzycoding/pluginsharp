using GBT.Plugin.Core;
using GBT.Plugin.Demo.Core;

namespace GBT.Plugin.Demo.FirstPlugin
{
    [Plugin(typeof(ThingyTwo))]
    public class ThingyTwo : IThingyTwo
    {
        public string Description { get; set; } = "Thingy Two";
    }
}
