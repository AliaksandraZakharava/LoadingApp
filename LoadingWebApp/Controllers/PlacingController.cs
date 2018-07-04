using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LoadingApp.Data;
using LoadingApp.DataProvider.Interfaces;
using LoadingApp.MathLib.Logic.Interfaces;
using LoadingApp.RenderDataProvider.Interfaces;
using LoadingApp.RenderDataProvider.Models;
using LoadingWebApp.Models;
using WebGrease.Css.Extensions;

namespace LoadingWebApp.Controllers
{
    public class PlacingController : ApiController
    {
        private readonly IModelingResultsProvider _modelingResultsProvider;
        private readonly IVisualizationDataProvider _visualizationDataProvider;
        private readonly IPredefinedDataProvider _predefinedDataProvider;

        public PlacingController(IModelingResultsProvider modelingResultsProvider, 
                                 IVisualizationDataProvider visualizationDataProvider,
                                 IPredefinedDataProvider predefinedDataProvider)
        {
            _modelingResultsProvider = modelingResultsProvider ?? throw new ArgumentNullException(nameof(modelingResultsProvider));
            _visualizationDataProvider = visualizationDataProvider ?? throw new ArgumentNullException(nameof(visualizationDataProvider));
            _predefinedDataProvider = predefinedDataProvider ?? throw new ArgumentNullException(nameof(predefinedDataProvider));
        }

        [HttpPost]
        [Route("~/api/placingPlan")]
        [ResponseType(typeof(VisualizationModel))]
        public IHttpActionResult GetPlacingPlan(PlacingModelRequest placingModelRequest)
        {
            if (placingModelRequest == null || placingModelRequest.Boxes == null || placingModelRequest.Container == null)
            {
                throw new ArgumentNullException("Null passed data.");
            }

            var boxes = GetBoxesListFromRequest(placingModelRequest);
            var container = _predefinedDataProvider.GetContainerByName(placingModelRequest.Container);

            var modelingResult = _modelingResultsProvider.GetLoadingAndPlacingPrograms(boxes, container);

            var placingPlan = _visualizationDataProvider.GetDataForRendering(modelingResult);

            return Ok(placingPlan);
        }

        #region Private methods

        private List<Box> GetBoxesListFromRequest(PlacingModelRequest placingModelRequest)
        {
            var boxes = new List<Box>();

            placingModelRequest.Boxes.ForEach(requset =>
            {
                var box = _predefinedDataProvider.GetBoxByName(requset.Key);
                box.OrderQuantity = requset.Value;
                boxes.Add(box);
            });

            return boxes;
        }

        #endregion
    }
}
