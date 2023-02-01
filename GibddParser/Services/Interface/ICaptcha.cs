using GibddParser.Models;

namespace GibddParser.Services.Interface;

public interface ICaptcha 
{
     public Task<string> CaptchaSolver(string base64Image);
     public Task<CaptchaModel> GetCaptcha(HttpClient httpClient);
}