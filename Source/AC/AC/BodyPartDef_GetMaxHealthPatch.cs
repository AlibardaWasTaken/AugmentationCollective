using System;
using HarmonyLib;
using Verse;

namespace AC
{
	[HarmonyPatch(typeof(BodyPartDef), "GetMaxHealth", MethodType.Normal)]
	internal class BodyPartDef_GetMaxHealthPatch
    {
		[HarmonyPostfix]
		public static void PostFix(BodyPartDef __instance, ref float __result, Pawn pawn)
		{
			foreach (Hediff hediff in pawn.health.hediffSet.hediffs)
			{
				BodyPartDef bodyPartDef;
				if (hediff == null)
				{
					bodyPartDef = null;
				}
				else
				{
					BodyPartRecord part = hediff.Part;
					bodyPartDef = ((part != null) ? part.def : null);
				}
				bool flag = bodyPartDef == __instance && hediff.TryGetComp<HediffComp_HealthMod>() != null;
				if (flag)
				{
					__result += hediff.TryGetComp<HediffComp_HealthMod>().Props.healthPointToAdd;
				}
			}
		}
	}
}
