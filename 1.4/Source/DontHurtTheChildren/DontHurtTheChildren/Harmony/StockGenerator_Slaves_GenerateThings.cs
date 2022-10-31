using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(StockGenerator_Slaves))]
    [HarmonyPatch("GenerateThings")]

    public static class StockGenerator_Slaves_GenerateThings_Patch
    {
        /*        static MethodInfo ChildrenAllowed = AccessTools.PropertyGetter("Difficulty:ChildrenAllowed");
                static MethodInfo myMethod = AccessTools.Method("StockGenerator_Slaves_GenerateThings_Patch:ChildSlaveAllowed");
                static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
                {
                    var codes = instructions.ToList();
                    for (int i = 0; i < codes.Count; i++)
                    {
                        if (codes[i].Calls(ChildrenAllowed))
                        {
                            yield return new CodeInstruction(OpCodes.Call, myMethod);   
                        }
                        else
                        {
                            yield return codes[i];
                        }
                    }
                }*/
        [HarmonyPostfix]
        static IEnumerable<Pawn> Postfix(IEnumerable<Pawn> values, StockGenerator_Slaves __instance,int forTile, Faction faction)
        {
            foreach(var p in values)
            {
                if (!p.DevelopmentalStage.Child())
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


}
