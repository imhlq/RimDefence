using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

using HarmonyLib;

namespace RimDefence
{
    [StaticConstructorOnStartup]
    public class Helper
    {
        static Helper()
        {
            var harmony = new Harmony("com.xhou.td");
            Log.Message("Hello Rim World");
        }
    }

    public class Utils
    {
        public static int cooldownTick = 0;
        public static void CallNextRaider()
        {
            Log.Message("Click CallNextRaider");
            Messages.Message("正在呼叫中，请做好准备", MessageTypeDefOf.ThreatBig);
            IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, Find.CurrentMap);
            incidentParms.forced = true;
            incidentParms.raidStrategy = RaidStrategyDefOf.ImmediateAttack;
            incidentParms.target = Find.CurrentMap;
            incidentParms.points = EnergyCore.dmDensity;
            // Arrival Mode
            bool arrivalRnd = Rand.Chance(0.75f);
            if (arrivalRnd)
            {
                incidentParms.raidArrivalMode = PawnsArrivalModeDefOf.EdgeDrop;
            }
            else
            {
                incidentParms.raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn;
            }
            // Add Incident
            Find.Storyteller.incidentQueue.Add(IncidentDefOf.RaidEnemy, Find.TickManager.TicksGame + 2500, incidentParms, 240000);
            Utils.cooldownTick = 60000;
        }

        public static void CallTrader()
        {
            Log.Message("Click CallTrader");
        }
    }

    public class EnergyCore : ThingComp
    {
        public static float dmDensity = 1.0f; // per cm3
        public float crossSection = 1.0f; // 1e-26cm3/s
        public float dmMass = 1.0f; // GeV

        protected float DesiredPowerOutput
        {
            get
            {
                // return Energy in game Unit
                return dmDensity * dmDensity * this.crossSection / this.dmMass;
            }
        }

        public override string CompInspectStringExtra()
        {
            string text = "";
            text += "暗物质密度:{0}".Translate(dmDensity);
            if(Utils.cooldownTick > 0)
            {
                text += '\n';
                text += "下拨敌人冷却:{0}Ticks".Translate(Utils.cooldownTick);
            }
            return text;
        }

        public override void CompTick()
        {
            // Power
            CompPowerPlant compPowerPlant = this.parent.TryGetComp<CompPowerPlant>();
            if (compPowerPlant == null) return;
            compPowerPlant.PowerOutput = this.DesiredPowerOutput;

            // Incident
            if (Utils.cooldownTick > 0)
            {
                Utils.cooldownTick--;
            }
            if(Utils.cooldownTick <= 0)
            {
                Utils.CallNextRaider();
            }
        }

    }

    public class CompUseEffect_VisitCore : CompUseEffect
    {
        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            yield return new Command_Action
            {
                action = delegate
                {
                    Utils.CallNextRaider();
                },
                defaultLabel = "呼叫下一波",
                defaultDesc = "可以召回下一波敌人入侵",
                hotKey = KeyBindingDefOf.Misc2,
                icon = TexCommand.Draft,
            };
            yield return new Command_Action
            {
                action = delegate
                {
                    Utils.CallTrader();
                },
                defaultLabel = "呼叫商人",
                defaultDesc = "可以呼叫商人交易",
                hotKey = KeyBindingDefOf.Misc3,
                icon = TexCommand.DesirePower,
            };
        }

        
    }
}
