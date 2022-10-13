using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(AttackTargetsCache))]
    [HarmonyPatch("GetPotentialTargetsFor")]

    public static class AttackTargetsCache_GetPotentialTargetsFor_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(ref List<IAttackTarget> __result)
        {
            if (!Settings.canBeRaidTarget)
            {
                return;
            }
            for (int i = 0; i < __result.Count; i++)
            {
                var p = __result[i] as Pawn;
                if (p != null && p.IsProtectedChild())
                {
                    __result.RemoveAt(i);
                }
            }
        }

    }


}
