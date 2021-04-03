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

    public class EnergyCore : CompPowerPlant
    {
        public float dmDensity = 1.0f; // per cm3
        public float crossSection = 1.0f; // 1e-26cm3/s
        public float dmMass = 10.0f; // GeV

        protected override float DesiredPowerOutput
        {
            get
            {
                // return Energy in game Unit
                return 1e6F * this.dmDensity * this.dmDensity * this.crossSection / this.dmMass;
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
                    CallNextRaider();
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
                    CallTrader();
                },
                defaultLabel = "呼叫商人",
                defaultDesc = "可以呼叫商人交易",
                hotKey = KeyBindingDefOf.Misc3,
                icon = TexCommand.DesirePower,
            };
        }

        public void CallNextRaider()
        {
            Log.Message("Click CallNextRaider");
        }

        public void CallTrader()
        {
            Log.Message("Click CallTrader");
        }
    }
}
