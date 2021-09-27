using PulsarModLoader.Chat.Commands.CommandRouter;
using PulsarModLoader.Utilities;

namespace StarmapBetterZoom
{
    class Commands : ChatCommand
    {
        public override string[] CommandAliases()
        {
            return new string[] { "starmapzoom", "smz" };
        }

        public override string Description()
        {
            return "controls the behavior of the StarmapBetterZoom plugin";
        }

        public override void Execute(string arguments)
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
                        Global.zoom = -woah*10;
                        Messaging.Notification($"Zoom precision level set to {woah}");
                    }
                    else
                    {
                        Messaging.Notification($"Argument not found, current value is {-Global.zoom/10}");
                    }
                    break;
                case "values":
                    Messaging.Notification($"Current zoom step is {-Global.zoom/10}");
                    break;
                case "reset":
                    Global.zoom = -10f;
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
        }

        public override string[][] Arguments()
        {
            return new string[][] { new string[] { "zoom", "values", "reset" }, new string[] { "%zoom_multiplier" } };
        }
    }
}
