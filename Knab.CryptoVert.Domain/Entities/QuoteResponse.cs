using Newtonsoft.Json;

namespace Knab.CryptoVert.Domain.Entities;

public class QuoteResponse
{
    [JsonProperty("data")]
    public Dictionary<string, CryptoSlug> Data { get; set; }
}

public class CryptoSlug
{
    [JsonProperty("quote")]
    public Dictionary<string, CurrencyQuote> Quote { get; set; }
}

public class CurrencyQuote
{
    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("volume_24h")]
    public decimal Volume24H { get; set; }

    [JsonProperty("volume_change_24h")]
    public decimal VolumeChange24H { get; set; }

    [JsonProperty("percent_change_1h")]
    public decimal PercentChange1H { get; set; }

    [JsonProperty("percent_change_24h")]
    public decimal PercentChange24H { get; set; }

    [JsonProperty("percent_change_7d")]
    public decimal PercentChange7D { get; set; }

    [JsonProperty("percent_change_30d")]
    public decimal PercentChange30D { get; set; }

    [JsonProperty("market_cap")]
    public decimal MarketCap { get; set; }

    [JsonProperty("market_cap_dominance")]
    public int MarketCapDominance { get; set; }

    [JsonProperty("fully_diluted_market_cap")]
    public decimal FullyDilutedMarketCap { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }
}