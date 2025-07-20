using HarmonyLib;
using System;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Linq.Expressions;




namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(AttackTargetFinder))]
    [HarmonyPatch("BestAttackTarget")]

    public static class AttackTargetFinder_BestAttackTarget_Patch
    {
        [HarmonyPrefix]
        public static void Prefix(ref Predicate<Thing> validator)
        {
            if (!Settings.canBeRaidTarget)
            {
                return;
            }
            Predicate<Thing> isChild;
            if (validator != null)
            {
                var oldValidator = validator;
                isChild = x => oldValidator.Invoke(x) && (!(x as Pawn)?.IsProtectedChild() ?? true);
            }
            else
            {
                isChild = x => !(x as Pawn)?.IsProtectedChild() ?? true;
            }
            validator = isChild;
        }

    }


}
