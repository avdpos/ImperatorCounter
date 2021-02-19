using ImperatorCounter.Common;
using ImperatorCounter.ViewModel;
using System.Collections.ObjectModel;

namespace ImperatorCounter.Viewmodel
{
    public class MainWindowModel : ViewModelBase
    {
        public MainWindowModel()
        {
            settings = new Settings();
            population = new TerritoryPopulation();
        }
        public Settings settings;
        public TerritoryPopulation population;

    }
}
