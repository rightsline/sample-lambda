using Amazon.Lambda.SNSEvents;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace RightslineSampleLambdaDotNetV4.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task CatalogItemCreated()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/catalog-item-created.json"));
        }

        [Fact]
        public async Task CatalogItemUpdated()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/catalog-item-updated.json"));
        }

        [Fact]
        public async Task CatalogItemDeleted()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/catalog-item-deleted.json"));
        }

        [Fact]
        public async Task RightCreated()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/right-created.json"));
        }

        [Fact]
        public async Task RightUpdated()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/right-updated.json"));
        }

        [Fact]
        public async Task RightDeleted()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/right-deleted.json"));
        }


        private async Task<bool> SendSNSMessageAsync(string jsonDataFile)
        {
            try
            {
                var text = File.ReadAllText(jsonDataFile);
                var function = new Function();

                SNSEvent snsEvent = new SNSEvent();
                snsEvent.Records = JsonConvert.DeserializeObject<SNSEvent.SNSRecord[]>(text);

                var response = await function.FunctionHandler(snsEvent, null);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return false;
        }

    }

}
