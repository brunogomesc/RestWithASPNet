using RestWithASPNet.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASPNet.Model
{
    public class BookVO
    {

        [JsonPropertyName("code")]
        public long Id { get; set; }

        public string Author { get; set; }

        [JsonPropertyName("launch_date")]
        public DateTime LaunchDate { get; set; }

        [JsonPropertyName("value")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public string Title { get; set; }

    }
}
