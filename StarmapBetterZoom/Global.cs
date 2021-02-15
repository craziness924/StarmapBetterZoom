using HarmonyLib;
using PulsarPluginLoader.Utilities;
using StarmapBetterZoom;

namespace StarmapBetterZoom
{
    class Global
    {
        public static float zoom = -20f;
    }
}
[HarmonyPatch(typeof(PLServer), "Start")]
class LoadPatch
{
    static void Postfix()
    {
        string[] settings = PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("StarmapBetterZoomSettings").Split(' ');
        if (settings.Length > 0)
        {
            bool errors = true;
            errors &= float.TryParse(settings[0], out Global.zoom);
            if (!errors)
            {
                Logger.Info("Something went wrong loading StarmapBetterZoom settings, could be conflicting mod. " + settings.Join());
            }
        }
        Logger.Info("Failed to load StarmapBetterZoom settings, or settings left on default!");
    }


}