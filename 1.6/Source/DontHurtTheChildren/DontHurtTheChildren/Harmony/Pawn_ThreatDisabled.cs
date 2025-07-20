using HarmonyLib;
using RimWorld;
using Verse;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(Pawn))]
    [HarmonyPatch("ThreatDisabled")]

    public static class Pawn_ThreatDisabled_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn __instance,ref bool __result)
        {
            if (!Settings.canBeRaidTarget && __instance.IsProtectedChild())
            {
                __result = true;    
            }
        }

    }


}
