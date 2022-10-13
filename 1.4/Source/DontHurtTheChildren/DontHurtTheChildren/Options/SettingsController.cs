using RimWorld;
using UnityEngine;
using Verse;


namespace DontHurtTheChildren
{



    public class DontHurtTheChildren_Mod : Mod
    {


        public DontHurtTheChildren_Mod(ModContentPack content) : base(content)
        {
            GetSettings<Settings>();
        }
        public override string SettingsCategory()
        {

            return "Dont Hurt the Children";


        }



        public override void DoSettingsWindowContents(Rect inRect)
        {
            Settings.DoWindowContents(inRect);
        }
    }


}
