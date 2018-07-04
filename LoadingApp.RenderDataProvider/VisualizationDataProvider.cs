using System.Collections.Generic;
using System.Linq;
using LoadingApp.MathLib.Logic.Models;
using LoadingApp.RenderDataProvider.Interfaces;
using LoadingApp.RenderDataProvider.Models;

namespace LoadingApp.RenderDataProvider
{
    public class VisualizationDataProvider : IVisualizationDataProvider
    {
        private const int Interval = 6;

        private readonly Dictionary<string, string> _boxColorDictionary;

        public VisualizationDataProvider()
        {
            _boxColorDictionary = new Dictionary<string, string>();
        }

        public VisualizationModel GetDataForRendering(ModelingResult modelingResult)
        {
            var result = new VisualizationModel
            {
                ExecutionPercent = modelingResult.ExecutionPercent,

                Container = new ContainerRenderingModel
                {
                    Name = modelingResult.Container.Name,
                    Width = modelingResult.Container.Width + Interval,
                    Length = modelingResult.Container.Length + Interval
                }
            };

            foreach (var line in modelingResult.PlacingPlan)
            {
                foreach (var box in line)
                {
                    var item = new BoxRenderingModel
                    {
                        LineNumber = modelingResult.PlacingPlan.IndexOf(line) + 1,
                        Xo = box.XPos + Interval,
                        X1 = box.XPos + box.Length + Interval,
                        Yo = box.YPos + Interval,
                        Y1 = box.YPos + box.Width + Interval,
                        Zo = box.ZPos + Interval,
                        Z1 = box.ZPos + box.Height + Interval,
                        Color = DefineBoxColor(box.Name),
                        Name = box.Name
                    };

                    result.Boxes.Add(item);
                }
            }

            return result;
        }

        #region Private methods

        private string DefineBoxColor(string boxName)
        {
            if (_boxColorDictionary.Keys.Contains(boxName))
            {
                return _boxColorDictionary[boxName];
            }

            var freeColor = Colors.Values.First(c => !_boxColorDictionary.Values.Contains(c));

            _boxColorDictionary.Add(boxName, freeColor);

            return freeColor;
        }

        #endregion
    }
}
