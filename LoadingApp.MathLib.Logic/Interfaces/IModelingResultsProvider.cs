using System.Collections.Generic;
using LoadingApp.Data;
using LoadingApp.MathLib.Logic.Models;

namespace LoadingApp.MathLib.Logic.Interfaces
{
    public interface IModelingResultsProvider
    {
        ModelingResult GetLoadingAndPlacingPrograms(List<Box> boxesForPlacing, Container container);
    }
}
