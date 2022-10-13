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
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref canBeRaidTarget, "canBeRaidTarget", false, true);
            Scribe_Values.Look(ref canBePrey, "canBePrey", false, true);
            Scribe_Values.Look(ref canEquipWeapons, "canEquipWeapons", false, true);
            Scribe_Values.Look(ref canTakeDamage, "canTakeDamage", false, true);
        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(inRect);
            ls.CheckboxLabeled("DHTC.canBeRaidTarget.Label".Translate(), ref canBePrey, "DHTC.canBeRaidTarget.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.Prey.Label".Translate(), ref canBePrey, "DHTC.Prey.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.CanTakeDamage.Label".Translate(), ref canBePrey, "DHTC.CanTakeDamage.Tooltip".Translate());
            ls.CheckboxLabeled("DHTC.canEquipWeapons.Label".Translate(), ref canBePrey, "DHTC.canEquipWeapons.Tooltip".Translate());
            ls.End();
        }



    }










}
