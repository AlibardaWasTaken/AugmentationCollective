using System;
using Verse;

namespace AC
{
    internal class HediffCompProperties_HealthMod : HediffCompProperties
    {
        public float healthPointToAdd = 0f;

        public HediffCompProperties_HealthMod()
        {
            compClass = typeof(HediffComp_HealthMod);
        }


    }


}
