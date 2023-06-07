using System.Text.Json.Serialization;

namespace ChatGPTApi.Models
{
    public class CompletionRequest
    {

        /*
            frequency_penalty=0,
            presence_penalty=0
        * */

        [JsonPropertyName("model")]
        public string? Model { get; set; } = "text-davinci-003";

        [JsonPropertyName("temperature")]
        public int Temperature { get; set; } = 1;

        [JsonPropertyName("top_p")]
        public int TopP { get; set; } = 1;

        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; } = 2000;

    }
}
