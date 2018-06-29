using System;
using System.Collections.Generic;
using System.Web.Http;
using LoadingApp.Data;
using LoadingApp.DataProvider.Interfaces;

namespace LoadingWebApp.Controllers
{
    public class DataProviderController : ApiController
    {
        private readonly IPredefinedDataProvider _predefinedDataProvider;

        public DataProviderController(IPredefinedDataProvider predefinedDataProvider)
        {
            _predefinedDataProvider = predefinedDataProvider ?? throw new ArgumentNullException(nameof(predefinedDataProvider));
        }

        [Route("~/api/data/boxes")]
        public IEnumerable<Box> GetPredefinedBoxes()
        {
            return _predefinedDataProvider.GetPredefinedBoxes();
        }

        [Route("~/api/data/containers")]
        public IEnumerable<Container> GetPredefinedContainers()
        {
            return _predefinedDataProvider.GetPredefinedContainers();
        }
    }
}
