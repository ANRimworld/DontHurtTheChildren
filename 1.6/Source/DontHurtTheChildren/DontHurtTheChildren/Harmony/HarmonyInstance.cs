using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;





namespace DontHurtTheChildren
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.DontHurtTheChildren");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        
    }

}
