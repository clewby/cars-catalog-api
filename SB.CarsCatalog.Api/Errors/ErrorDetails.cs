using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Errors
{
    /// <summary>
    /// Error details
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Status code
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
