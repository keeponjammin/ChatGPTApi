using System.Text.Json;
using System.Text;

namespace ChatGPTApi.Models
{
    public class HttpRequestMessageModel
    {
        public string? ApiKey { get; set; }
        public string? Prompt { get; set; }

        public HttpRequestMessage GetHttpRequestMessage() 
        {
            CompletionRequest completionRequest = new()
            {
                Prompt = Prompt,
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions");
            httpRequestMessage.Headers.Add("Authorization", $"Bearer {ApiKey}");
            string requestString = JsonSerializer.Serialize(completionRequest);
            httpRequestMessage.Content = new StringContent(requestString, Encoding.UTF8, "application/json");

            return httpRequestMessage;
        }
    }
}
