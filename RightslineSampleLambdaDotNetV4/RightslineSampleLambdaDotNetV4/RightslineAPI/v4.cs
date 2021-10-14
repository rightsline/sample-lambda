using RightsLine.Contracts.RestApi.V4;
using RightslineSampleLambdaDotNetV4.Consts;
using RightslineSampleLambdaDotNetV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RightslineSampleLambdaDotNetV4.RightslineAPI
{
    public class v4 : BaseFacade
    {
        public v4()
        {
        }

        public async Task<EntityRestModel> Get(string endpoint, long id)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<EntityRestModel>($"{endpoint}/" + id.ToString(), HttpMethod.Get);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on {endpoint} GET: {ex.Message}");
            }
        }

        public async Task<EntityRestModel> Put(string endpoint, long id, string entityJSON)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<EntityRestModel>($"{endpoint}/" + id.ToString(), HttpMethod.Put, entityJSON);

                return response;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error on {endpoint} PUT: {ex.Message}");
            }
        }

        public async Task<int> Post(string endpoint, string entityJSON)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<int>($"{endpoint}", HttpMethod.Post, entityJSON);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on {endpoint} Post: {ex.Message}");
            }
        }

        public async Task<bool> Delete(string endpoint, long id)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<bool>($"{endpoint}/" + id.ToString(), HttpMethod.Delete);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on {endpoint} Delete: {ex.Message}");
            }
        }

        public async Task<IEnumerable<EntityRestModel>> Search(string endpoint, string query)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<EntitySearchResponse>($"{endpoint}/search", HttpMethod.Post, query);

                var numFound = response.NumFound;

                return response.Entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {endpoint} SEARCH: {ex.Message}");
            }
        }
    }
}
