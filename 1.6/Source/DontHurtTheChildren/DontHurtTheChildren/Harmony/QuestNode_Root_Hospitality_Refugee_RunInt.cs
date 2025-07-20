using HarmonyLib;
using RimWorld;
using Verse;
using RimWorld.QuestGen;
using Verse.AI;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(QuestNode_Root_Hospitality_Refugee))]
    [HarmonyPatch("RunInt")]

    public static class QuestNode_Root_Hospitality_Refugee_RunInt_Patch
    {
        static FieldInfo allowViolent = AccessTools.Field("Difficulty:allowViolentQuests");
        static MethodInfo myMethod = AccessTools.Method("QuestNode_Root_Hospitality_Refugee_RunInt_Patch:NoChildBetray");
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = instructions.ToList();
            object pawnsInfo = null;
            for (int i = 0; i < codes.Count; i++)
            {
                //This is caue display classes are fun
                if (codes[i].opcode == OpCodes.Newobj )
                {
                    var obj = codes[i].operand as ConstructorInfo;
                    if (obj.ReflectedType == typeof(List<Pawn>))
                    {
                        pawnsInfo = codes[i + 1].operand;
                    }                   
                }
                if (codes[i].LoadsField(allowViolent))
                {
                    yield return codes[i];
                    yield return new CodeInstruction(OpCodes.Ldloc_0);
                    yield return new CodeInstruction(OpCodes.Ldfld, pawnsInfo);
                    yield return new CodeInstruction(OpCodes.Call, myMethod);   
                }
                else
                {
                    yield return codes[i];
                }
            }
        }
        public static bool NoChildBetray(bool allowViolent, List<Pawn> pawns)
        {
            if (Settings.noKidBetray && pawns.Any(x=>x.DevelopmentalStage.Child()) || !allowViolent)
            {
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(QuestPart_RefugeeInteractions))]
    [HarmonyPatch("AssaultColony")]
    public static class QuestPart_RefugeeInteractions_AssaultColony_Patch
    {
        static MethodInfo Dead = AccessTools.PropertyGetter("Pawn:Dead");
        static MethodInfo myMethod = AccessTools.Method("QuestPart_RefugeeInteractions_AssaultColony_Patch:ChildorDead");
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = instructions.ToList();
            
            for (int i = 0; i < codes.Count; i++)
            {

                if (codes[i].Calls(Dead))
                {
                    yield return new CodeInstruction(OpCodes.Call, myMethod);
                }
                else
                {
                    yield return codes[i];
                }
            }
        }
        public static bool ChildorDead(Pawn pawn)
        {
            if (Settings.noKidBetray && pawn.DevelopmentalStage.Child() || pawn.Dead)
            {
                return true;
            }
            return false;
        }
    }
}
