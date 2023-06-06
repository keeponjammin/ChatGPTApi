using System.Text.Json.Serialization;

namespace ChatGPTApi.Models
{
    public class CompletionRequest
    {
        [JsonPropertyName("model")]
        public string? Model { get; set; } = "text-davinci-003";

        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; } = 100;
    }
}
