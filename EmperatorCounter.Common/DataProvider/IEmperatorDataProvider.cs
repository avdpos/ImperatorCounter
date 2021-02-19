using System;
using System.Collections.Generic;
using System.Text;

namespace ImperatorCounter.Common.DataProvider
{
    interface IEmperatorDataProvider
    {
        IEnumerable<Population> LoadPopulation();
        IEnumerable<TerritoryPopulation> LoadTerritoryPopulation();
    }
}
