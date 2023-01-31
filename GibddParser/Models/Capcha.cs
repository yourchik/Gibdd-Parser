using Newtonsoft.Json;

namespace GibddParser.Models;

public class Capcha
{
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("base64jpg")]
        public string Base64 { get; set; }
}