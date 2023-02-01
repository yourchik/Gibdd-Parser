namespace Gibdd_Parser;

public class AppSettings
{
    public static string RuCaptchaKey => Configuration.GetSection("RuCaptchaApiKey").Value;
    public static string History => Configuration.GetSection("StateRoadSafetyInspectorateUrls").GetSection("History").Value;
    public static string TrafficAccident => Configuration.GetSection("StateRoadSafetyInspectorateUrls").GetSection("TrafficAccident").Value;
    public static string Restriction => Configuration.GetSection("StateRoadSafetyInspectorateUrls").GetSection("Restriction").Value;
    public static string Wanted  => Configuration.GetSection("StateRoadSafetyInspectorateUrls").GetSection("Wanted").Value;
    
    private static IConfiguration config;
    public static IConfiguration Configuration {
        get
        {
            if (config != null)
                return config;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            config = builder.Build();
            return config;
        }
    }
}