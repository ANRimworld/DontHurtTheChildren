using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(EquipmentUtility))]
    [HarmonyPatch("CanEquip") ]
    [HarmonyPatch(new Type[] { typeof(Thing), typeof(Pawn), typeof(string), typeof(bool) },new[] {ArgumentType.Normal,ArgumentType.Normal,ArgumentType.Out,ArgumentType.Normal})]

    public static class EquipmentUtility_CanEquip_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(ref bool __result, Thing thing, Pawn pawn, ref string cantReason, bool checkBonded = true)
        {
            if (__result)
            {
                if (!Settings.canEquipWeapons && thing.def.IsWeapon && pawn.IsProtectedChild())
                {
                    __result = false;
                    cantReason = "DHTC.ChildCantEquip".Translate();
                }
            }

        }

    }


}
