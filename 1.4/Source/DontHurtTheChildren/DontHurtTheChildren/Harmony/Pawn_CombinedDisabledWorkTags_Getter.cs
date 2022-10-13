using HarmonyLib;
using System;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Linq.Expressions;




namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(Pawn))]
    [HarmonyPatch("CombinedDisabledWorkTags", MethodType.Getter)]
    

    public static class Pawn_CombinedDisabledWorkTags_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn __instance, ref WorkTags __result)
        {
            if (__instance.IsProtectedChild())
            {
                __result |= WorkTags.Violent;
            }
        }

    }


}
