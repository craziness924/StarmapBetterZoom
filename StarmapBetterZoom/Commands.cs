using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;
using StarmapBetterZoom;

namespace StarmapBetterZoom
{
    class Commands : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "starmapzoom", "smz" };
        }

        public string Description()
        {
            return "controls the behavior of the StarmapBetterZoom plugin";
        }

        public bool Execute(string arguments, int SenderID)
        {
            string[] args = arguments.Split(' ');
            bool yes = false;
            float woah = -1;
            if (args.Length > 1)
            {
                yes = float.TryParse(args[1], out woah);

            }
            switch (args[0].ToLower())
            {
                case "zoom":
                    if (yes)
                    {
                        Global.zoom = -woah;
                        Messaging.Notification($"Zoom precision level set to {woah}");
                    }
                    else
                    {
                        Messaging.Notification($"Argument not found, current value is {-Global.zoom}");
                    }
                    break;
                case "values":
                    Messaging.Notification($"Current zoom step is {-Global.zoom}");
                    break;
                case "reset":
                    Global.zoom = -20f;
                    PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("StarmapBetterZoomSettings", $"{Global.zoom}");
                    Messaging.Notification("Zoom step level reset to default!");
                    break;
                default:
                    Messaging.Notification("Subcommand not found");
                    break;
            }
            if (yes)
            {
                PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("StarmapBetterZoomSettings", $"{Global.zoom}");
            } 
            return false;
        }

        public bool PublicCommand()
        {
            return false;
        }

        public string UsageExample()
        {
            return "/starmapzoom [zoom | values | reset]";
        }
    }
}
