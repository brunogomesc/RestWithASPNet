using RestWithASPNet.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASPNet.Data.VO
{
    public class PersonVO 
    {

        [JsonPropertyName("code")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string FirstName { get; set; }

        [JsonIgnore]
        public string LastName { get; set; }

        [JsonIgnore]
        public string Adress { get; set; }

        [JsonPropertyName("sex")]
        public string Gender { get; set; }

    }
}
