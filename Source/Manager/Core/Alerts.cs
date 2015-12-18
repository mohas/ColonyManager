﻿using System.Linq;
using RimWorld;
using Verse;

namespace FM
{
    class Alert_NoTable : Alert
    {
        public override AlertPriority Priority => AlertPriority.Medium;

        public override AlertReport Report
        {
            get { return Manager.Get.JobStack.FullStack().Count > 0 && !AnyManagerTable(); }
        }

        private bool AnyManagerTable()
        {
            return Find.ListerBuildings.AllBuildingsColonistOfClass<Building_ManagerStation>().Any();
        }

        public Alert_NoTable()
        {
            this.baseLabel = "FM.AlertNoTableLabel".Translate();
            this.baseExplanation = "FM.AlertNoTable".Translate();
        }
    }

    class Alert_NoManager : Alert
    {
        public override AlertPriority Priority => AlertPriority.Medium;

        public override AlertReport Report
        {
            get { return Manager.Get.JobStack.FullStack().Count > 0 && !AnyConsciousManagerPawn(); }
        }

        private bool AnyConsciousManagerPawn()
        {
            return
                Find.ListerPawns.FreeColonistsSpawned.Any(
                    pawn => !pawn.health.Dead && !pawn.Downed &&
                            pawn.workSettings.WorkIsActive( Utilities.WorkTypeDefOf_Managing ) );
        }

        public Alert_NoManager()
        {
            this.baseLabel = "FM.AlertNoManagerLabel".Translate();
            this.baseExplanation = "FM.AlertNoManager".Translate();
        }
    }
}
