using Newtonsoft.Json;

namespace GibddParser.Models;

    public class HistoryResponse
    {
        [JsonProperty("requestTime")]
        public string RequestTime { get; set; }

        [JsonProperty("RequestResult")]
        public RequestResult RequestResult { get; set; }
    }
    
    public class RequestResult
    {
        [JsonProperty("ownershipPeriods")]
        public OwnershipPeriods OwnershipPeriods { get; set; }

        [JsonProperty("vehiclePassport")]
        public VehiclePassport VehiclePassport { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle Vehicle { get; set; }
    }

    public class OwnershipPeriods
    {
        [JsonProperty("ownershipPeriod")]
        public List<OwnershipPeriod> OwnershipPeriod { get; set; }
    }

    public class OwnershipPeriod
    {
        // Здесь тоже словарь
        [JsonProperty("lastOperation")]
        public string LastOperation { get; set; }
        // И здесь
        [JsonProperty("simplePersonType")]
        public string SimplePersonType { get; set; }

        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }
    }

    public class VehiclePassport
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }
    }

    public class Vehicle
    {
        [JsonProperty("engineVolume")]
        public float EngineVolume { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("bodyNumber")]
        public string BodyNumber { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("engineNumber")]
        public string EngineNumber { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        // Организовать словарь
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("powerHp")]
        public float PowerHp { get; set; }

        [JsonProperty("powerKwt")]
        public float PowerKwt { get; set; }
    }