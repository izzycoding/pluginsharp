using GBT.Plugin.Core;
using GBT.Plugin.Demo.Core;

namespace GBT.Plugin.Demo.SecondPlugin
{
    [Plugin(typeof(ThingyThree))]
    public class ThingyThree : IThingyOne, IThingyTwo
    {
        public string Name { get; set; } = "Third Thingy";
        public string Description { get; set; } = "Thingy Three";
    }
}
