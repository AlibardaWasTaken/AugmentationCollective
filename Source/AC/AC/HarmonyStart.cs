using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace AC
{
    [StaticConstructorOnStartup]
    internal class HarmonyStart
    {
        static HarmonyStart()
        {
            Harmony harmony = new Harmony("alibarda.collective");
            harmony.PatchAll();
        }
    }
}
