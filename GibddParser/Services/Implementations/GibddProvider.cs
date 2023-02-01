using System.Net;
using GibddParser.Models;
using GibddParser.Services.Interface;
using Newtonsoft.Json;

namespace GibddParser.Services.Implementations;

public class GibddProvider : IGibddProvider
{
    private readonly ICaptcha _captcha;
    public GibddProvider(ICaptcha captcha)
    {
        _captcha = captcha;
    }
    
    public async Task<Response<T>> GetResponse<T>(string number, string checkType, string url) where T : class
    {
        try
        {
            return new Response<T>(true, "Данные успешно полученны", await GetInfo<T>(number, checkType, url));
        }
        catch (Exception e)
        {
            return new Response<T>(false, e.Message, null);
        }
    }
    
    public async Task<T> GetInfo<T>(string number, string checkType, string url) where T : class
    {
        try
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.All;
            using (var httpClient = new HttpClient(handler))
            {
                var captcha = await _captcha.GetCaptcha(httpClient);

                var code = await _captcha.CaptchaSolver(captcha.Base64);

                if (code == "-1")
                    return new Response<T>(false, "Ошибка решения капчи", null) as T;

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("vin", number),
                    new KeyValuePair<string, string>("checkType", checkType),
                    new KeyValuePair<string, string>("captchaWord", code),
                    new KeyValuePair<string, string>("captchaToken", captcha.Token)
                });

                var responseMessage = await httpClient.PostAsync(new Uri(url), formContent);

                var response = responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(response.Result);
                return result;
            }
        }
        catch (Exception e)
        {
            if (e.Message == null)
            {
                throw new Exception("Ошибка при получении информации с сайта ГИБДД");
            }
            throw;
        }
    }
}