using Gibdd_Parser;
using GibddParser.Models;
using GibddParser.Services.Interface;
using Newtonsoft.Json;
using TwoCaptcha.Captcha;

namespace GibddParser.Services.Implementations;

public class Captcha : ICaptcha
{
    public async Task<string> CaptchaSolver(string base64Image)
    {
        var ruCaptchaKey = AppSettings.RuCaptchaKey;
        TwoCaptcha.TwoCaptcha solver = new TwoCaptcha.TwoCaptcha(ruCaptchaKey);
        solver.DefaultTimeout = 14;
        solver.PollingInterval = 5;
        var code = "-1";

        Normal captcha = new Normal();
        captcha.SetBase64(base64Image);
        captcha.SetLang("ru");

        try
        {
            await solver.Solve(captcha);
            code = captcha.Code;
        }
        catch (Exception e)
        {
            if (e.Message == null)
            {
                throw new Exception("Ошибка при решении капчи");
            }
            throw;
        }
        return code;
    }
    public async Task<CaptchaModel> GetCaptcha(HttpClient httpClient)
    {
        try
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://check.gibdd.ru/captcha"))
            {
                request.Headers.TryAddWithoutValidation("Accept", "*/*");
                request.Headers.TryAddWithoutValidation("Accept-Language", "ru,en-US;q=0.9,en;q=0.8");
                request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                request.Headers.TryAddWithoutValidation("Origin", "https://xn--90adear.xn--p1ai");
                request.Headers.TryAddWithoutValidation("Referer", "https://xn--90adear.xn--p1ai/");
                request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
                request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
                request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "cross-site");
                request.Headers.TryAddWithoutValidation("User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36");
                request.Headers.TryAddWithoutValidation("sec-ch-ua", "^^");
                request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "^^");

                var response = await httpClient.SendAsync(request);

                var responseBody = await response.Content.ReadAsStringAsync();
                var captcha = JsonConvert.DeserializeObject<CaptchaModel>(responseBody);
            
                return captcha;
            }
        }
        catch (Exception e)
        {
            throw new Exception("Ошибка при получении капчи");
        }
    }
}