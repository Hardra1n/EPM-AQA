using System;
using System.Text.Json.Serialization;

namespace QAAutomationLab.CoreLayer.APIElement
{
    public class SuccessNewApp
    {
        [JsonPropertyName("applicant_id")]
        public int ApplicantId { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("linkedin")]
        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public string HomePage { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
