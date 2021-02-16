using PulsarPluginLoader; //

namespace StarmapBetterZoom
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.1";

        public override string Author => "craziness924";

        public override string Name => "StarmapBetterZoom";

        public override string HarmonyIdentifier()
        {
            return "craziness924.StarmapBetterZoom";
        }
    }
}
