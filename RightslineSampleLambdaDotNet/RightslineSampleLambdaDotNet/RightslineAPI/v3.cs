using RightslineSampleLambdaDotNet.Consts;
using RightslineSampleLambdaDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RightslineSampleLambdaDotNet.RightslineAPI
{
    public class v3 : BaseFacade
    {
        public v3()
        {
        }

        public async Task<TemplatesResponse> GetTemplates(string endpoint)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<TemplatesResponse>(endpoint + "-templates", HttpMethod.Get);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on {endpoint} GET: {ex.Message}");
            }
        }

        public async Task<EntityModel> Get(string endpoint, long id)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<EntityModel>($"{endpoint}/" + id.ToString(), HttpMethod.Get);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on {endpoint} GET: {ex.Message}");
            }
        }

        public async Task<EntityModel> Put(string endpoint, long id, string entityJSON)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<EntityModel>($"{endpoint}/" + id.ToString(), HttpMethod.Put, entityJSON);

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

        public async Task<IEnumerable<EntityModel>> Search(string endpoint, string query)
        {
            try
            {
                var response = await this.GatewayApiClient.Request<EntitySearchModel>($"{endpoint}/search", HttpMethod.Post, query);

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
