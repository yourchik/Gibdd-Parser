using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using GibddParser.Models;
using GibddParser.Provider;
using Microsoft.AspNetCore.Mvc;

namespace GibddParser.Controllers;

[ApiController]
[Route("[controller]")]
public class GetGibddController : ControllerBase
{
    public GetGibddController(IGibddProvider gibddProvider)
    {
        _gibddProvider = gibddProvider;
    }
    private readonly IGibddProvider _gibddProvider;
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true
    };
    
    [HttpGet("History")]
    public async Task<string> Get(string number)
    {
        var result = await _gibddProvider.GetInfo<HistoryResponseModel>(number, "history", "https://xn--b1afk4ade.xn--90adear.xn--p1ai/proxy/check/auto/history");
        return JsonSerializer.Serialize(result, _serializerOptions);
    }
    
    [HttpGet("TrafficAccident")]
    public async Task<string> GetDtp(string number)
    {
        var result = await _gibddProvider.GetInfo<DtpResponseModel>(number, "dtp", "https://xn--b1afk4ade.xn--90adear.xn--p1ai/proxy/check/auto/dtp");
        return JsonSerializer.Serialize(result, _serializerOptions);
    }

    [HttpGet("Restriction")]
    public async Task<string> GetRestrictions(string number)
    {
        var result = await _gibddProvider.GetInfo<RestrictResponseModel>(number, "restrictions", "https://xn--b1afk4ade.xn--90adear.xn--p1ai/proxy/check/auto/restriction");
        return JsonSerializer.Serialize(result, _serializerOptions);
    }
    
    [HttpGet("Wanted")]
    public async Task<string> GetWanted(string number)
    {
        var result = await _gibddProvider.GetInfo<WantedResponseModel>(number, "wanted", "https://xn--b1afk4ade.xn--90adear.xn--p1ai/proxy/check/auto/wanted");
        return JsonSerializer.Serialize(result, _serializerOptions);
    }
}
