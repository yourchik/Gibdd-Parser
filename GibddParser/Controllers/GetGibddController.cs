using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Gibdd_Parser;
using GibddParser.Models;
using GibddParser.Services.Interface;
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
    public async Task<string> GetHistory(string number)
    {
        var result = await _gibddProvider.GetResponse<HistoryResponse>(number, "history", AppSettings.History);
        return JsonSerializer.Serialize(result, _serializerOptions);
    }
    
    [HttpGet("TrafficAccident")]
    public async Task<string> GetDtp(string number)
    {
        var result = await _gibddProvider.GetResponse<DtpResponse>(number, "dtp", AppSettings.TrafficAccident);
        return JsonSerializer.Serialize(result, _serializerOptions);
    }

    [HttpGet("Restriction")]
    public async Task<string> GetRestrictions(string number)
    {
        var result = await _gibddProvider.GetResponse<RestrictResponse>(number, "restrictions", AppSettings.Restriction);
        return JsonSerializer.Serialize(result, _serializerOptions);
    }
    
    [HttpGet("Wanted")]
    public async Task<string> GetWanted(string number)
    {
        var result = await _gibddProvider.GetResponse<WantedResponse>(number, "wanted", AppSettings.Wanted);
        return JsonSerializer.Serialize(result, _serializerOptions);
    }
}
