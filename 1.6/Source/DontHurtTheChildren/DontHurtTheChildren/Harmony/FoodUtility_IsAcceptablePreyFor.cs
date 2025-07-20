using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(FoodUtility))]
    [HarmonyPatch("IsAcceptablePreyFor")]

    public static class FoodUtility_IsAcceptablePreyFor_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(ref bool __result, Pawn prey)
        {
            if (!Settings.canBePrey && prey.IsProtectedChild())
            {
                __result = false;
            }

        }

    }


}
