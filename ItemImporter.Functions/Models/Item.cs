using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ItemImporter.Functions.Models
{
    public class Item
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("handle")]
        public string Handle { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("price_min")]
        public int PriceMin { get; set; }

        [JsonPropertyName("price_max")]
        public int PriceMax { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }

        [JsonPropertyName("price_varies")]
        public bool PriceVaries { get; set; }

        [JsonPropertyName("compare_at_price")]
        public double CompareAtPrice { get; set; }

        [JsonPropertyName("compare_at_price_min")]
        public double CompareAtPriceMin { get; set; }

        [JsonPropertyName("compare_at_price_max")]
        public double CompareAtPriceMax { get; set; }

        [JsonPropertyName("compare_at_price_varies")]
        public bool CompareAtPricVaries { get; set; }

        [JsonPropertyName("requires_selling_plan")]
        public bool RequiresSellingPlan { get; set; }
    }
}
