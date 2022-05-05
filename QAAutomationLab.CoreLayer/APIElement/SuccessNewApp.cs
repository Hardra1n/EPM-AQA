using System;
using System.Text.Json.Serialization;

namespace QAAutomationLab.CoreLayer.APIElement
{
    public class SuccessNewApp
    {
        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("user_id")]
        public int user_id { get; set; }

        [JsonPropertyName("phone_number")]
        public string phone_number { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("linkedin")]
        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public string HomePage { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
