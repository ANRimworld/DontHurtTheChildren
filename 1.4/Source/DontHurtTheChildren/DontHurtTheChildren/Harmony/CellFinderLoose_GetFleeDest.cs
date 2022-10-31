using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System.Linq;



namespace DontHurtTheChildren
{

    [HarmonyPatch(typeof(CellFinderLoose))]
    [HarmonyPatch("GetFleeDest")]

    public static class CellFinderLoose_GetFleeDest_Patch
    {
        //Doing this as prefix due to vanilla find safe spot being fairly costly already so running both during a postfix would harm performance even more
        [HarmonyPrefix] 
        public static bool Prefix(ref IntVec3 __result, Pawn pawn, List<Thing> threats)
        {
            if (Settings.betterFleeDestination && pawn.IsProtectedChild())
            {
                return !TryFindSafeSpot(pawn, threats, out __result);
            }
            return true;

        }

        public static bool TryFindSafeSpot(Pawn pawn, List<Thing> threats, out IntVec3 result)
        {
            var parents = pawn.relations.FamilyByBlood.Where(x=>x.Map == pawn.Map);
            result = IntVec3.Invalid;
            foreach (var parent in parents)
            {
                if (parent.Spawned && parent.Downed && parent.mindState?.enemyTarget == null && !threats.Any(x => parent.Position.DistanceTo(x.Position) <= 20f))
                {
                    result = parent.Position;
                    return true;
                }
            }
            var bed = pawn.ownership?.OwnedBed;
            if (bed != null && !threats.Any(x => bed.Position.DistanceTo(x.Position) <= 20f))
            {
                result = bed.Position;
                return true;
            }
            foreach(var friendly in pawn.Map.mapPawns.FreeColonistsSpawned)
            {
                if(!friendly.Downed && friendly.mindState?.enemyTarget == null && !threats.Any(x => friendly.Position.DistanceTo(x.Position) <= 20f))
                {
                    result = friendly.Position;
                    return true;
                }
            }
            return false;
        }
    }


}
