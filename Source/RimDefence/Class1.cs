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
}
