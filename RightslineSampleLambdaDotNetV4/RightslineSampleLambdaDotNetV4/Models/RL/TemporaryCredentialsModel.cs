using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightsLine.Contracts.RestApi.V4
{
    public class TemporaryCredentialsModel
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string SessionToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
