using Newtonsoft.Json;

namespace GibddParser.Models;

public class RestrictResponse
{
    [JsonProperty("requestTime")]
    public string RequestTime { get; set; }

    [JsonProperty("RequestResult")]
    public RequestResultRestrict RequestResult { get; set; }
}

public class RequestResultRestrict
{
    [JsonProperty("records")]
    public List<RecordRestrict> Records { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("error")]
    public int Error { get; set; }
}

public class RecordRestrict
{
    [JsonProperty("regname")]
    public string InitRegion { get; set; }

    [JsonProperty("osnOgr")]
    public string RestrictDocument { get; set; }
    [JsonProperty("gid")]
    public string RestrictId { get; set; }
   
    [JsonProperty("tsyear")]
    public string AutoReleaseYear { get; set; }

    [JsonProperty("tsVIN")]
    public string Vin { get; set; }

    [JsonProperty("codDL")]
    public string CodDl { get; set; }

    [JsonProperty("dateogr")]
    public string StartRestrictDate { get; set; }

    [JsonProperty("ogrkod")]
    public string RestrictCode { get; set; }

    [JsonProperty("tsmodel")]
    public string Model { get; set; }

    [JsonProperty("tsKuzov")]
    public string BodyNumber { get; set; }

    [JsonProperty("codeTo")]
    public string CodeTo { get; set; }

    [JsonProperty("dateadd")]
    public string DateAdd { get; set; }

    [JsonProperty("phone")]
    public string RestricterPhoneNumber { get; set; }
    
    [JsonProperty("regid")]
    public string RegId { get; set; }
    
    [JsonProperty("divtype")]
    public string RestricterType { get; set; }

    [JsonProperty("divid")]
    public string RestricterTypeId { get; set; }
}