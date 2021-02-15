using HarmonyLib;
using PulsarPluginLoader.Patches;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StarmapBetterZoom
{
    class ZoomFix
    {
        [HarmonyPatch(typeof(PLStarmap), "Update")]
        internal class ZoomPatch
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                List<CodeInstruction> TargetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, -10f),
                new CodeInstruction(OpCodes.Mul),
            };
                List<CodeInstruction> InjectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Global), "zoom")),
                new CodeInstruction(OpCodes.Mul),
            };
                return HarmonyHelpers.PatchBySequence(instructions, TargetSequence, InjectedSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NONNULL);
            }
        }
    }
}

