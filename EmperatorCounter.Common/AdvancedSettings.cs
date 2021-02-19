using System;
using System.Collections.Generic;
using System.Text;

namespace ImperatorCounter.Common
{
    public class Settings
    {
        public Settings()
        {
            Buildings = new Buildings();
            Governor = new Governor();
            LawsHeritage = new LawsAndHeritage();
            Tech = new Tech();
            GodsAndOmens = new GodsAndOmens();
        }
        public Buildings Buildings;
        public Governor Governor;
        public LawsAndHeritage LawsHeritage;
        public Tech Tech;
        public GodsAndOmens GodsAndOmens;
    }
}
