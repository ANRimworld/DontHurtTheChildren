using RimWorld;
using UnityEngine;
using Verse;
using System;


namespace DontHurtTheChildren
{


    public class Settings : ModSettings

    {
        public static bool canBeRaidTarget = false;
        public static bool canBePrey = false;
        public static bool canEquipWeapons = true;
        public static bool canTakeDamage = true;
        public static bool betterFleeDestination = true;
        public static bool tradersCanSellChildren = true;
        public static bool manInBlack = true;
        public static bool noKidBetray = true;
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref canBeRaidTarget, "canBeRaidTarget", false, true);
            Scribe_Values.Look(ref canBePrey, "canBePrey", false, true);
            Scribe_Values.Look(ref canEquipWeapons, "canEquipWeapons", false, true);
            Scribe_Values.Look(ref canTakeDamage, "canTakeDamage", false, true);
            Scribe_Values.Look(ref betterFleeDestination, "betterFleeDestination", false, true);
            Scribe_Values.Look(ref tradersCanSellChildren, "tradersCanSellChildren", false, true);
            Scribe_Values.Look(ref manInBlack, "manInBlack", false, true);
            Scribe_Values.Look(ref noKidBetray, "noKidBetray", false, true);
        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(inRect);
            ls.CheckboxLabeled("DHTC.canBeRaidTarget.Label".Translate(), ref canBeRaidTarget, "DHTC.canBeRaidTarget.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.Prey.Label".Translate(), ref canBePrey, "DHTC.Prey.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.CanTakeDamage.Label".Translate(), ref canTakeDamage, "DHTC.CanTakeDamage.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.canEquipWeapons.Label".Translate(), ref canEquipWeapons, "DHTC.canEquipWeapons.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.betterFleeDestination.Label".Translate(), ref betterFleeDestination, "DHTC.betterFleeDestination.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.tradersCanSellChildren.Label".Translate(), ref tradersCanSellChildren, "DHTC.tradersCanSellChildren.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.manInBlack.Label".Translate(), ref manInBlack, "DHTC.manInBlack.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.noKidBetray.Label".Translate(), ref noKidBetray, "DHTC.noKidBetray.Tooltip".Translate());
            ls.End();
        }



    }










}
