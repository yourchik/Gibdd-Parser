using Newtonsoft.Json;

namespace GibddParser.Models;

public class WantedResponse
{
    [JsonProperty("requestTime")]
    public string RequestTime { get; set; }

    [JsonProperty("RequestResult")]
    public RequestResultWanted RequestResult { get; set; }
}
public class RequestResultWanted
{
    [JsonProperty("records")]
    public List<RecordWanted> Records { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("error")]
    public int Error { get; set; }
}
public class RecordWanted
{
    [JsonProperty("w_rec")]
    public int Rec { get; set; }

    [JsonProperty("w_reg_inic")]
    public string InitRegion { get; set; }

    [JsonProperty("w_user")]
    public string User { get; set; }

    [JsonProperty("w_kuzov")]
    public string BodyNumber { get; set; }

    [JsonProperty("w_model")]
    public string Model { get; set; }

    [JsonProperty("w_data_pu")]
    public string AccountingWanted { get; set; }

    [JsonProperty("w_vin")]
    public string Vin { get; set; }

    [JsonProperty("w_god_vyp")]
    public string ReleaseYear { get; set; }

    [JsonProperty("w_vid_uch")]
    public string VidUsh { get; set; }

    [JsonProperty("w_un_gic")]
    public string UnGic { get; set; }
}