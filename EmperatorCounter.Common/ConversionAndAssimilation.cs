using System;
using System.Collections.Generic;
using System.Text;

namespace ImperatorCounter.Common
{
    class ConversionAndAssimilation
    {

        private int _GovernorFinesse;
        private double _GovernorAssimilationPolicy;
        private double _GovernorConvertionPolicy;
        private int _Theaters;
        private int _Temples;
        private double _AssimilationBasevalue;
        private double _ConvertionBasevalue;
        private double _isCapital;
        private double _isBuddhist;
        private double _missMatchingDietis;
        private double _isJew;
        private double _grandTemple;
        private double _culturalAdministration;
        private double _techReligousAssimilation;
        private double _assimilationOmens;
        private double _conversionOmens;
        private double _religousLaws;
        private double _defiedRulersInPantheon;
        private double _isStateCulture;
        private double _isStateReligion;

        private double _religousGod;
        private double _heritagePercantageAssimilation;
        private double _heritagePercantageConversion;
        private double _roadNetwork;
        private double _majorityCultureEffectingAssimilation;
        private double _majorityCultureEffectingConversion;
        private double _majorityReligionEffectingConversion;
        private double _majorityReligionEffectingAssimilation;
        private double _assimilationLawValue;
        private double _assimilationLawPercantage;
        private double _provincialLegation;
        private double _assimilationDietis;
        public void UpdateSettings(Settings settings)
        {
            //Governor
            GovernorFinesse = settings.Governor.GovernorFinesse;
            GovernorAssimilationPolicy(settings.Governor.AssimilationPolicy);
            GovernorConvertionPolicy(settings.Governor.ConversionPolicy);
            //Tech
            CulturalAdministration(settings.Tech.CulturalAdministration);
            GrandTemple(settings.Tech.GrandTemple);
            TechReligousAssimilation(settings.Tech.ReligousAssimilation);
            //Buildings
            Temples =settings.Buildings.Temples;
            Theaters = settings.Buildings.Theaters;
            ProvincialLegation(settings.Buildings.ProvincialLegation);
            Capital(settings.Buildings.IsCapital);
            RoadNetwork(settings.Buildings.RoadNetwork);
            //Laws and Heritage
            AssimilationLaws(settings.LawsHeritage.AssimilationLaws);
            ReligousLaws(settings.LawsHeritage.ReligousLaws);
            IsJew(settings.LawsHeritage.IsJewish);
            IsBuddhist(settings.LawsHeritage.IsBuddhist);
            Heritages(settings.LawsHeritage.Heritage);
            //GodsAndOmens
            AssimilationOmens(settings.GodsAndOmens.AssimilationOmens);
            ConversionOmens(settings.GodsAndOmens.ConversionOmens);
            AssimilationDietis(settings.GodsAndOmens.AssimilationDietis);
            ReligousDietis(settings.GodsAndOmens.ReligousDietis);
            MissMatchingDietis(Convert.ToInt32(settings.GodsAndOmens.MissMatchingDietis));
            DefiedRulersInPantheon(Convert.ToInt32(settings.GodsAndOmens.DefiedRulersInPantheon));

        }
        public void ChangingNumbersDuringProcessing(TerritoryPopulation allPops, Population pops, int temples, int theaters, bool AssimilationPolicy, bool ConvertionPolicy)
        {
            Majorities(allPops);
            Pop(pops);
            Temples = temples;
            Theaters = theaters;
            GovernorAssimilationPolicy(AssimilationPolicy);
            GovernorConvertionPolicy(ConvertionPolicy);
        }
        private double _AssimilationRate()
        {
            return _AssimilationValue() * _AssimilationPercantage();
        }
        private double _ConvertionRate()
        {
            return _ConvertionValue() * _ConvertionPercentage();
        }
        private double _AssimilationValue()
        {
            double result = _AssimilationBasevalue + _GovernorAssimilationPolicy + _Theaters + _isCapital 
                               + _provincialLegation + _assimilationLawValue;
            return result;
        }
        private double _ConvertionValue()
        {
            double result = _ConvertionBasevalue + _GovernorConvertionPolicy + _Temples +  _grandTemple ;
            return result;

        }
        private double _AssimilationPercantage()
        {
            double result = 1 + _isStateReligion + _majorityCultureEffectingAssimilation + _majorityReligionEffectingAssimilation 
                                + _assimilationOmens + _heritagePercantageAssimilation + _roadNetwork + _assimilationLawPercantage
                                + _culturalAdministration + _isJew + _assimilationDietis;
            return result;
        }
        private double _ConvertionPercentage()
        {
            double result = 1 + _isStateCulture + _majorityCultureEffectingConversion + _majorityReligionEffectingConversion +_techReligousAssimilation 
                                + _isCapital + _isBuddhist + _religousLaws + _missMatchingDietis + _conversionOmens 
                                + _defiedRulersInPantheon + _heritagePercantageConversion + _roadNetwork
                                + _religousGod ;
            return result;
        }

        public double AssimilationRate
        { get { return _AssimilationRate(); } }
        public double ConvertionRate
        { get { return _ConvertionRate(); } }

        public int GovernorFinesse { 
            get { return _GovernorFinesse; } 
            set { _GovernorFinesse = value; } }
        public void GovernorAssimilationPolicy(bool isActive)
        {
            if(isActive)
            {
                _GovernorAssimilationPolicy = 0.1 + 0.1 * _GovernorFinesse;
            }
            else if (!isActive)
            { _GovernorAssimilationPolicy = 0; }
        }
        public void GovernorConvertionPolicy(bool isActive)
        {
            if (isActive)
            {
                _GovernorConvertionPolicy = 0.3 + 0.3 * _GovernorFinesse;
            }
            else if (!isActive)
            { _GovernorConvertionPolicy = 0; }
        }

        
        public void Pop(Population pop)
        {
            if (pop.StateCulture)
            {
                _isStateCulture = 0;
            }
            else if (!pop.StateCulture)
            {
                _isStateCulture = -0.2;
            }
            if (!pop.StateReligion)
            { _isStateReligion = -0.33; }
            else if (pop.StateReligion)
            { _isStateReligion = 0;  }
            BaseValues(pop.CitizenClass);
        }
        public void BaseValues(int Citizenclass)
        {
            if (Citizenclass == 1)
            {
                _AssimilationBasevalue = 0.6;
                _ConvertionBasevalue = 0.6;
            }
            else if (Citizenclass == 2)
            {
                _AssimilationBasevalue = 0.4;
                _ConvertionBasevalue = 0.4;
            }
            else if (Citizenclass == 3)
            {
                _AssimilationBasevalue = 0.3;
                _ConvertionBasevalue = 0.4;
            }     
        }

        public void Majorities(TerritoryPopulation pops)
        {
            if (!pops.MajorityCulture)
            {
                _majorityCultureEffectingAssimilation = -0.25;
                _majorityCultureEffectingConversion = -0.1;
            }
            else if (pops.MajorityCulture)
            {
                _majorityCultureEffectingAssimilation = 0;
                _majorityCultureEffectingConversion = 0;
            }
            if (!pops.MajorityReligion)
            {
                _majorityReligionEffectingConversion = -0.25;
                _majorityReligionEffectingAssimilation = -0.1;
            }
            else if (pops.MajorityReligion)
            {
                _majorityReligionEffectingConversion = 0;
                _majorityReligionEffectingAssimilation = 0;
            }
        }
        public void Capital(bool isCapital)
        {
            if (isCapital)
                _isCapital = 0.2;
            else
                _isCapital = 0;
        }
        public int Theaters { set { _Theaters = value; } }
        public int Temples { set { _Temples = value; } }
        public void IsBuddhist(bool isBuddhist)
        { if (isBuddhist)
                _isBuddhist = 0.3;
            else if (!isBuddhist)
                _isBuddhist = 0;
        }
        public void IsJew(bool isJew)
        {
            if (isJew)
                _isJew = 0.2;
            else if (!isJew)
                _isJew = 0;
        }
        public void MissMatchingDietis(int number)
        {
            _missMatchingDietis = number * -0.2;
        }
        public void GrandTemple(bool grandTemple)
        {
            if (grandTemple)
                _grandTemple = 0.5;
            else if (!grandTemple)
                _grandTemple = 0;
        }
        public void CulturalAdministration(bool culturalAdministration)
        {
            if (culturalAdministration)
                _culturalAdministration = 0.1;
            else if (!culturalAdministration)
                _culturalAdministration = 0;
        }
        public void TechReligousAssimilation(bool techReligousAssimilation)
        {
            if (techReligousAssimilation)
                _techReligousAssimilation = 0.1;
            else if (!techReligousAssimilation)
                _techReligousAssimilation = 0;
        }
        public void ReligousLaws(string law)
        {
            if (law == "No religious law")
                _religousLaws = 0;
            else if (law == "Religous conversion (Monarchy)")
                _religousLaws = 0.3;
            else
                _religousLaws = 0.2;
        }
        public void AssimilationLaws(string law)
        {
            if (law == "No law")
            {
                _assimilationLawValue = 0;
                _assimilationLawPercantage = 0;
            }
            else if (law == "Cultural Dissemination (Monarchy)") //Cultural Dissemination
            {
                _assimilationLawValue = 3;
                _assimilationLawPercantage = 0;
            }
            else if (law == "Oral Tradition (Tribal)") //Oral Tradition
            {
                _assimilationLawValue = 0;
                _assimilationLawPercantage = 0.3;
            }
        }
        public void AssimilationOmens(string assimilationOmens)
        {
            if (assimilationOmens == "No effecting omens")
                _assimilationOmens = 0;
            else if (assimilationOmens == "Cybele or Belisama without holy site")
                _assimilationOmens = 0.1;
            else if (assimilationOmens == "Cybele or Belisama with holy site")
                _assimilationOmens = 0.125;
        }
        public void ConversionOmens(string conversionOmens)
        {
            if (conversionOmens == "None")
                _conversionOmens = 0;
            else if (conversionOmens == "Trapusa and Bahalika, Intrabus, Eacus or Zoroaster without holy site")
                _conversionOmens = 0.1;
            else if (conversionOmens == "Trapusa and Bahalika, Intrabus, Eacus or Zoroaster with holy site")
                _conversionOmens = 0.125;
        }
        public void DefiedRulersInPantheon(int defiedRulersInPantheon)
        {
            _defiedRulersInPantheon = defiedRulersInPantheon * 0.15;
        }
        public void ReligousDietis(string god)
        {
            if(god=="0")
            {
                _religousGod = 0;
            }
            else if (god=="Zeus Ammon, Esther or Saulaia without holy site")
            {
                _religousGod = 0.05;
            }
            else
            {
                _religousGod = 0.0625;
            }
        }
        public void Heritages(string heritage)
        {
            if (heritage == "No effecting heritage") //No effecting heritage
            { 
                _heritagePercantageAssimilation = 0;
                _heritagePercantageConversion = 0; 
            }
            else if (heritage == "Kalingan Heritage") //Kalingan Heritage
            {
                _heritagePercantageAssimilation = 0.1;
                _heritagePercantageConversion = 0;
            }
            else if (heritage == "Decapolian Heritage") //Decapolian Heritage
            {
                _heritagePercantageAssimilation = 0.1;
                _heritagePercantageConversion = 0;
            }
            else if (heritage == "Nabatean Heritage") //Nabatean Heritage
            {
                _heritagePercantageAssimilation = 0;
                _heritagePercantageConversion = -0.05;
            }
            else if (heritage == "Judean Heritage") //Judean Heritage
            {
                _heritagePercantageAssimilation = 0;
                _heritagePercantageConversion = -0.25;
            }
            else if (heritage == "Heritage of Byblos") //Heritage of Byblos
            {
                _heritagePercantageAssimilation = -0.05;
                _heritagePercantageConversion = 0;
            }
            else if (heritage == "Bosporan Heritage") //Bosporan Heritage
            {
                _heritagePercantageAssimilation = -0.1;
                _heritagePercantageConversion = 0;
            }
            else if (heritage == "Heritage of Ptolemaios") //Heritage of Ptolemaios
            {
                _heritagePercantageAssimilation = -0.15;
                _heritagePercantageConversion = 0;
            }
            else if (heritage == "Heritage of Seleukos") //Heritage of Seleukos
            {
                _heritagePercantageAssimilation = -0.15;
                _heritagePercantageConversion = 0;
            }
            else if (heritage == "Hellenistic Heritage") //Hellenistic Heritage
            {
                _heritagePercantageAssimilation = -0.15;
                _heritagePercantageConversion = 0;
            }
        }
        public void RoadNetwork(int roads)
        {
            _roadNetwork = 0.025 * roads;
        }
        public void ProvincialLegation(int number)
        {
            _provincialLegation = 0.2 * number;
        }
        public void AssimilationDietis(int number)
        {
            if (number == 1)
                _assimilationDietis = 0;
            else if (number == 2)
                _assimilationDietis = 0.05;
            else if (number == 3)
                _assimilationDietis = 0.0625;
        }
        

       
    }
}
