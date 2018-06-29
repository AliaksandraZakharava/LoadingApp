using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadingApp.MathLib.Logic.Models;
using LoadingApp.RenderDataProvider.Models;

namespace LoadingApp.RenderDataProvider.Interfaces
{
    public interface IVisualizationDataProvider
    {
        VisualizationModel GetDataForRendering(ModelingResult modelingResult);
    }
}
