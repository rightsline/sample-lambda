using System;
using System.Collections.Generic;
using System.Text;

namespace RightslineSampleLambdaDotNet.RightslineAPI.Requests
{
    public class TemporaryCredentialsRequest
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }

        public TemporaryCredentialsRequest(string accessKey, string secretKey)
        {
            this.AccessKey = accessKey;
            this.SecretKey = secretKey;
        }
    }
}
