using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Models
{
    public class RequestData
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public bool isError { get; set; }
        public object result { get; set; }
        [JsonProperty("responseException")]

        public ResponseException responseException { get; set; }
    }
    public class ResponseException
    {
        public string exceptionMessage { get; set; }
    }
}
