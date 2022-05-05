using System.Text.Json.Serialization;

namespace QAAutomationLab.CoreLayer.APIElement
{
    public class AppElements
    {
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("linkedin")]
        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public string HomePage { get; set; }
    }
}
