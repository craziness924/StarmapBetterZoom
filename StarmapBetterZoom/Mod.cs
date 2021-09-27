using HarmonyLib;
using PulsarModLoader;
using PulsarModLoader.Utilities;

namespace StarmapBetterZoom
{
    public class Mod : PulsarMod
    {
        public Mod() : base()
        {
            string[] settings = PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("StarmapBetterZoomSettings").Split(' ');
            if (settings.Length > 0)
            {
                if (float.TryParse(settings[0], out float zoom))
                {
                    Global.zoom = zoom;
                }
                else
                {
                    Logger.Info("Something went wrong loading StarmapBetterZoom settings, could be conflicting mod. " + settings.Join());
                }
            }
            else
            {
                Logger.Info("Failed to load StarmapBetterZoom settings, or settings left on default!");
            }
        }

        public override string Version => "1.2";

        public override string Author => "craziness924, Updated by 18107";

        public override string Name => "StarmapBetterZoom";

        public override string HarmonyIdentifier()
        {
            return "craziness924.StarmapBetterZoom";
        }
    }
}
