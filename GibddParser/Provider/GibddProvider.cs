using System.Net;
using Gibdd_Parser;
using GibddParser.Models;
using Newtonsoft.Json;
using TwoCaptcha.Captcha;

namespace GibddParser.Provider;

public class GibddProvider : IGibddProvider
{
    public async Task<T> GetInfo<T>(string number, string checkType, string url) where T : class
    {
        var handler = new HttpClientHandler();
        handler.AutomaticDecompression = DecompressionMethods.All;
        using (var httpClient = new HttpClient(handler))
        {
            var captcha = await GetCapcha(httpClient);
            var code = await CaptchaSolver(captcha.Base64);
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

    private async Task<Capcha> GetCapcha(HttpClient httpClient)
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

            string responseBody = await response.Content.ReadAsStringAsync();
            var captcha = JsonConvert.DeserializeObject<Capcha>(responseBody);
            
            return captcha;
        }
    }

    private async Task<string> CaptchaSolver(string base64image)
    {
        var RuCaptchaKey = AppSettings.RuCaptchaKey;
        TwoCaptcha.TwoCaptcha solver = new TwoCaptcha.TwoCaptcha(RuCaptchaKey);
        solver.DefaultTimeout = 14;
        solver.PollingInterval = 5;
        var code = "0";

        Normal captcha = new Normal();
        captcha.SetBase64(base64image);
        captcha.SetLang("ru");

        try
        {
            await solver.Solve(captcha);
            code = captcha.Code;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred: " + e.Message);
        }

        return code;
    }
}
