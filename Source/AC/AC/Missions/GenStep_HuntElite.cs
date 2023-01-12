using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI.Group;

namespace AC.Missions
{
    public class GenStep_HuntElite : GenStep_Scatterer
    {
        public override int SeedPart
        {
            get
            {
                return 930582965;
            }
        }

        protected override bool CanScatterAt(IntVec3 loc, Map map)
        {
            return base.CanScatterAt(loc, map) && loc.Standable(map);
        }


        protected override void ScatterAt(IntVec3 loc, Map map, GenStepParams parms, int count = 1) { 

            Faction faction = Faction.OfAncientsHostile;           
			if (Find.FactionManager.FirstFactionOfDef(AC_DefOf.TheAugmentationCollective) != null)
			{
				faction = Find.FactionManager.FirstFactionOfDef(AC_DefOf.TheAugmentationCollective);
			}

            List<PawnKindDef> pawnKindDeflist = new List<PawnKindDef> {
            AC_DefOf.Collective_EliteMemberMelee,
            AC_DefOf.Collective_EliteMemberMeleeEmp,
            AC_DefOf.Collective_EliteMemberShooter
        };

           

            Pawn pawn = PawnGenerator.GeneratePawn(GenCollection.RandomElement<PawnKindDef>(pawnKindDeflist), faction);
            pawn.mindState.exitMapAfterTick = 500000;
            GenSpawn.Spawn(pawn, loc, map, 0);

            List<Pawn> list = new List<Pawn>();
            list.Add(pawn);

            MapGenerator.rootsToUnfog.Add(loc);
            MapGenerator.SetVar<CellRect>("RectOfInterest", CellRect.CenteredOn(loc, 1, 1));
            LordMaker.MakeNewLord(faction, new LordJob_DefendBase(faction, loc, true), map, list);
        }


    }
}
