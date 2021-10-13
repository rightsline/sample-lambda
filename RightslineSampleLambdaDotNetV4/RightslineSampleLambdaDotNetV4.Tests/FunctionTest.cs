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
        public async Task RightsetCreated()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/rightset-created.json"));
        }

        [Fact]
        public async Task RightsetUpdated()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/rightset-updated.json"));
        }

        [Fact]
        public async Task RightsetDeleted()
        {
            await SendSNSMessageAsync(Path.GetFullPath("./../../../Data/rightset-deleted.json"));
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
