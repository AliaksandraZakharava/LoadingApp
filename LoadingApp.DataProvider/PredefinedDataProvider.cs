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
                new Box("Fridge", length: 60, width: 60, height: 200),
                new Box("Washing machine", length: 55, width: 60, height: 80),
                new Box("Electric kettle", length: 20, width: 20, height: 30)
            };
        }

        public IEnumerable<Container> GetPredefinedContainers()
        {
            // Get from database

            return new List<Container>
            {
                new Container("Container type A", 50D, 300, 200, 200),
                new Container("Container type B", 100D, 400, 300, 200)
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
