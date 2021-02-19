using System;
using System.Collections.Generic;
using System.Linq;

namespace ImperatorCounter.Common
{
    public class TerritoryPopulation
    {
        public TerritoryPopulation()
        {
            _territoryPopulation = new List<Population>();
        }

        private bool _majorityCulture;
        private bool _majorityReligion;
        private List<Population> _territoryPopulation;
        public bool MajorityCulture { get { return _majorityCulture; } }
        public bool MajorityReligion { get { return _majorityReligion; } }

        public void AddPopulation(Population pop)
        {
            _territoryPopulation.Add(pop);
            CountMajority();
        }
        public void UpdatePopulation(Population pop)
        {
            foreach (Population updatePop in _territoryPopulation.Where(x => x.ID == pop.ID))
            {
                updatePop.StateCulture = pop.StateCulture;
                updatePop.StateReligion = pop.StateReligion;
            }
            CountMajority();
        }

        private void CountMajority()
        {
            double totalStateCulture = _territoryPopulation.Count(x => x.StateCulture = true);
            double totalStateReligion = _territoryPopulation.Count(x => x.StateReligion = true);
            double totalPopulation = _territoryPopulation.Count();

            if (totalStateCulture >= totalPopulation / 2)
                _majorityCulture = true;
            else
                _majorityCulture = false;

            if (totalStateReligion >= totalPopulation / 2)
                _majorityReligion = true;
            else
                _majorityReligion = false;
            
        }
    }
}