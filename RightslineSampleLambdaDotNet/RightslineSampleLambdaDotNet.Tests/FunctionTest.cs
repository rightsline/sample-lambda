using Amazon.Lambda.SQSEvents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace RightslineSampleLambdaDotNet.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task CatalogItemUpdated()
        {
            try
            {
                var rightslineMessage = File.ReadAllText(Path.GetFullPath("./../../../Data/catalog-item-updated.json"));
                var function = new Function();
                SQSEvent sqsEvent = new SQSEvent();

                SQSEvent.SQSMessage message = new SQSEvent.SQSMessage
                {
                    MessageId = Guid.NewGuid().ToString(),
                    Body = rightslineMessage
                };

                sqsEvent.Records = new List<SQSEvent.SQSMessage>() { message };

                var response = await function.FunctionHandler(sqsEvent, null);
            }
            finally
            {

            }
        }
    }
}
