using System.Collections.Generic;
using System.Linq;
using LoadingApp.Data;
using LoadingApp.DataProvider.Interfaces;

namespace LoadingApp.DataProvider
{
    public class PredefinedDataProvider : IPredefinedDataProvider
    {
        public IEnumerable<Box> GetPredefinedBoxes()
        {
            // Get from database

            return new List<Box>
            {
                new Box("Fridge", length: 60, width: 60, height: 200, cost: 100, weight: 90),
                new Box("Washing machine", length: 55, width: 60, height: 80, cost: 70, weight: 65),
                new Box("Electric kettle", length: 20, width: 20, height: 30, cost: 20, weight: 2)
            };
        }

        public IEnumerable<Container> GetPredefinedContainers()
        {
            // Get from database

            return new List<Container>
            {
                new Container("Container type A", 5000D, 400, 300, 300),
                new Container("Container type B", 10000D, 400, 300, 200)
            };
        }

        public Box GetBoxByName(string name)
        {
            return GetPredefinedBoxes().SingleOrDefault(box => box.Name == name);
        }

        public Container GetContainerByName(string name)
        {
            return GetPredefinedContainers().SingleOrDefault(container => container.Name == name);
        }
    }
}
