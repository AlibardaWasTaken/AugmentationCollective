using System;
using Verse;

namespace AC
{
	internal class HediffComp_HealthMod : HediffComp
	{
		public HediffCompProperties_HealthMod Props
		{
			get
			{
				return (HediffCompProperties_HealthMod)this.props;
			}
		}
	}
}
