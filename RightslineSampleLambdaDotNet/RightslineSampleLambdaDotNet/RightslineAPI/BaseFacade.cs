using RightslineSampleLambdaDotNet.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightslineSampleLambdaDotNet.RightslineAPI
{
    public abstract class BaseFacade
    {
        protected string ApiUrl = Environment.GetEnvironmentVariable(EnvironmentVariables.ApiUrl);
        protected string ApiKey = Environment.GetEnvironmentVariable(EnvironmentVariables.ApiKey);
        protected string AccessKey = Environment.GetEnvironmentVariable(EnvironmentVariables.AccessKey);
        protected string SecretKey = Environment.GetEnvironmentVariable(EnvironmentVariables.SecretKey);

        protected readonly RightslineAPIGatewayClient GatewayApiClient;

        public BaseFacade()
        {
            this.GatewayApiClient = new RightslineAPIGatewayClient(this.ApiUrl, this.ApiKey, this.AccessKey, this.SecretKey);
        }
    }
}
