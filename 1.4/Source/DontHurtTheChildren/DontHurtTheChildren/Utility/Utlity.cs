using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace DontHurtTheChildren
{
    public static class Utility
    {
        public static bool IsProtectedChild(this Pawn pawn)
        {
            return pawn.DevelopmentalStage.Child() && pawn.RaceProps.Humanlike && pawn.equipment?.Primary == null;
        }
    }
}
