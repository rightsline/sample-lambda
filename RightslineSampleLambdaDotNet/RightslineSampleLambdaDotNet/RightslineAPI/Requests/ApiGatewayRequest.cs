using System;
using System.Collections.Generic;
using System.Text;

namespace RightslineSampleLambdaDotNet.RightslineAPI.Requests
{
    public class ApiGatewayRequest
    {
        public string RegionName { get; set; }

        public string AbsolutePath { get; set; }

        public string QueryString { get; set; }

        public string JsonData { get; set; }

        public string RequestMethod { get; set; }

        public int? RequestTimeout { get; set; }
    }
}
