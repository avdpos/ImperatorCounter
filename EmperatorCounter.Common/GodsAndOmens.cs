using System;
using System.Collections.Generic;
using System.Text;

namespace ImperatorCounter.Common
{
    public class GodsAndOmens
    {
        public GodsAndOmens()
        {
            ReligousDietis = "No effecting dietis";
            DefiedRulersInPantheon = "0";
            MissMatchingDietis = "0";
            AssimilationDietis = "0";
            ConversionOmens = "None";
            AssimilationOmens = "No effecting omens";
        }
        public string ReligousDietis;
        public string AssimilationDietis;
        public string DefiedRulersInPantheon;
        public string MissMatchingDietis;

        public string AssimilationOmens;
        public string ConversionOmens;
    }
}
