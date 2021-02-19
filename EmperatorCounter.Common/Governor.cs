using System;
using System.Collections.Generic;
using System.Text;

namespace ImperatorCounter.Common
{
    public class Governor
    {
        public Governor()
        {
            _Finesse = 10;
            AssimilationPolicy = false;
            ConversionPolicy = false;
            ChangePolicyOnMajority = false;
        }
        public int GovernorFinesse
        {
            get { return _Finesse; }
        }
        public string SetFinesse
        {
            set { _Finesse = Convert.ToInt32(value); }
            get { return Convert.ToString(GovernorFinesse); }
        }
        public string SetPolicy
        {
            get 
            {
                if (!AssimilationPolicy && !ConversionPolicy && !ChangePolicyOnMajority)
                    return "no effecting policy";
                else if (AssimilationPolicy && !ConversionPolicy && !ChangePolicyOnMajority)
                    return "Assimilation";
                else if (!AssimilationPolicy && ConversionPolicy && !ChangePolicyOnMajority)
                    return "Conversion";
                else if (AssimilationPolicy && ChangePolicyOnMajority)
                    return "Assimilation until majority, then conversion";
                else
                    return "Conversion until majority, then conversion";
            }
            set {
                AssimilationPolicy = false;
                ConversionPolicy = false;
                ChangePolicyOnMajority = false;
                if (value == "Assimilation")
                    AssimilationPolicy = true;
                else if (value == "Conversion")
                    ConversionPolicy = true;
                else if (value == "Assimilation until majority, then conversion")
                {
                    AssimilationPolicy = true;
                    ChangePolicyOnMajority = true;
                }
                else if (value == "Conversion until majority, then conversion")
                {
                    ConversionPolicy = true;
                    ChangePolicyOnMajority = true;
                }
                else if (value == "no effecting policy")
                {
                    AssimilationPolicy = false;
                    ConversionPolicy = false;
                    ChangePolicyOnMajority = false;
                }
            }
        }
        public bool AssimilationPolicy;
        public bool ConversionPolicy;
        public bool ChangePolicyOnMajority;
        private int _Finesse;
    }
}
