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
    [HarmonyPatch("PreApplyDamage")]

    public static class Pawn_PreApplyDamage_Patch
    {
        [HarmonyPrefix]
        public static void Prefix(Pawn __instance, ref DamageInfo dinfo)
        {
            if (!Settings.canTakeDamage)
            {
                if (__instance.IsProtectedChild() && __instance.Faction.IsPlayer)
                {
                    dinfo.SetAmount(0f);
                }
            }
        }

    }


}
