using System.Collections.Generic;
using LoadingApp.Data;

namespace LoadingApp.DataProvider.Interfaces
{
    public interface IPredefinedDataProvider
    {
        IEnumerable<Box> GetPredefinedBoxes();

        IEnumerable<Container> GetPredefinedContainers();

        Box GetBoxByName(string name);

        Container GetContainerByName(string name);
    }
}
