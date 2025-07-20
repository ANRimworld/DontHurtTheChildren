/*using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;

///Removes 1.6 as functionality is a part of the base game now.
namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(StockGenerator_Slaves))]
    [HarmonyPatch("GenerateThings")]

    public static class StockGenerator_Slaves_GenerateThings_Patch
    {
        [HarmonyPostfix]
        static IEnumerable<Thing> Postfix(IEnumerable<Thing> values, StockGenerator_Slaves __instance,int forTile, Faction faction)
        {            
            foreach(Pawn p in values)
            {
                if (!p.DevelopmentalStage.Child() || Settings.tradersCanSellChildren)
                {
                    yield return p;
                }
                else
                {
                   if(!Find.FactionManager.AllFactions.Where(x=>!x.IsPlayer && x.def.humanlikeFaction && !x.temporary).TryRandomElement(out var fac))
                    {
                        continue;
                    }
                    PawnGenerationRequest request = new PawnGenerationRequest((__instance.slaveKindDef != null) ? __instance.slaveKindDef : PawnKindDefOf.Slave, fac, PawnGenerationContext.NonPlayer, forTile, false, false, false, true, false, 1f, !__instance.trader.orbital, true, false, true, true, false, false, false, false, 0f, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, false, null, null, null, null, null, 0f, DevelopmentalStage.Adult, null, null, null, false);
                    yield return PawnGenerator.GeneratePawn(request);
                }
                
            }
        }
        public static bool ChildSlaveAllowed()
        {
            if (!Settings.tradersCanSellChildren)
            {
                return false;
            }
            return Find.Storyteller.difficulty.ChildrenAllowed;
        }
    }


}*/
