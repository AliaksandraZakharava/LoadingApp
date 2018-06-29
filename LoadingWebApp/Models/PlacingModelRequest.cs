using System.Collections.Generic;

namespace LoadingWebApp.Models
{
    public class PlacingModelRequest
    {
        public Dictionary<string, int> Boxes { get; set; }

        public string Container { get; set; }
    }
}