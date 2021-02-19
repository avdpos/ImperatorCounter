using System;
using System.Collections.Generic;
using System.Text;

namespace ImperatorCounter.Common
{
    public class Buildings
    {
        public Buildings()
            {
            Temples = 0;
            Theaters = 0;
            _rebuildTemples = 0;
            _rebuildTheaters = 0;
            _ProvincialLegation = 0;
            _roadNetwork = 0;
            IsCapital = false;
            }
        public int Temples
        {
            get { return _temple; }
            set { _temple = value; }
        }
        public string SetTemple
        {
            get { return Convert.ToString(_temple); }
            set => _temple = Convert.ToInt32(value);
        }
        public int Theaters
        {
            get { return _theater; }
            set { _theater = value; }
        }
        public string SetTheaters
        {
            get { return Convert.ToString(_theater); }
            set => _theater = Convert.ToInt32(value);
        }
        public int RebuildTemples
        {
            get { return _rebuildTemples; }
        }
        public string SetRebuildTemples
        {
            get { return Convert.ToString(_rebuildTemples); }
            set { _rebuildTemples = Convert.ToInt32(value); }
        }

        public int RebuildTheaters
        {
            get { return _rebuildTheaters; }
        }
        public string SetRebuildTheaters
        { 
            get { return Convert.ToString(_rebuildTheaters); }
            set { _rebuildTheaters = Convert.ToInt32(value); } }
        public int ProvincialLegation
        {
            get { return _ProvincialLegation; }
        }
        public string SetProvincialLegation
        {
            get { return Convert.ToString(ProvincialLegation); }
            set { _ProvincialLegation = Convert.ToInt32(value); }
        }
        public int RoadNetwork
        {
            get { return _roadNetwork; }
        }
        public string SetRoadNetwork
        {
            get { return Convert.ToString(RoadNetwork); }
        set { _roadNetwork = Convert.ToInt32(value); }
        }

        public bool IsCapital;

        private int _temple;
        private int _theater;
        private int _rebuildTheaters;
        private int _rebuildTemples;
        private int _ProvincialLegation;
        private int _roadNetwork;
    }
}
