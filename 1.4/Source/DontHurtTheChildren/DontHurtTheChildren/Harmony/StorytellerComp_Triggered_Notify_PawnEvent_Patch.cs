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

    [HarmonyPatch(typeof(StorytellerComp_Triggered))]
    [HarmonyPatch("Notify_PawnEvent")]

    public static class StorytellerComp_Triggered_Notify_PawnEvent_Patch
    {
        static MethodInfo Downed = AccessTools.PropertyGetter("Pawn:Downed");
        static MethodInfo myMethod = AccessTools.Method("StorytellerComp_Triggered_Notify_PawnEvent_Patch:DownedOrChild");
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = instructions.ToList();
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Calls(Downed))
                {
                    yield return new CodeInstruction(OpCodes.Call, myMethod);   
                }
                else
                {
                    yield return codes[i];
                }
            }
        }
        public static bool DownedOrChild(Pawn pawn)
        {
            if (Settings.manInBlack && pawn.IsProtectedChild())
            {
                return false;
            }
            return !pawn.Downed;
        }
    }


}
