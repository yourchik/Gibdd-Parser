using Newtonsoft.Json;

namespace GibddParser.Models;

public class DtpResponse
{
    [JsonProperty("requestTime")]
    public string RequestTime { get; set; }

    [JsonProperty("RequestResult")]
    public RequestResultDtp RequestResult { get; set; }
}

public class RequestResultDtp
{
    [JsonProperty("Accidents")]
    public List<Accident> Accidents { get; set; }
}

public class Accident
{
    [JsonProperty("AccidentDateTime")]
    public string AccidentDateTime { get; set; }

    [JsonProperty("VehicleModel")]
    public string VehicleModel { get; set; }
        
    [JsonProperty("VehicleDamageState")]
    public string VehicleDamageState { get; set; }

    [JsonProperty("RegionName")]
    public string RegionName { get; set; }

    [JsonProperty("AccidentNumber")]
    public string AccidentNumber { get; set; }

    [JsonProperty("AccidentType")]
    public string AccidentType { get; set; }

    [JsonProperty("VehicleMark")]
    public string VehicleMark { get; set; }

    [JsonProperty("DamagePoints")]
    public List<string> DamagePoints { get; set; }

    [JsonProperty("VehicleYear")]
    public string VehicleYear { get; set; }
}