using System.Text.Json;

namespace ChatGPTApi.Models
{
    public class HttpResponseMessageModel
    {
        public HttpResponseMessage? HttpResponseMessage { get; set; }
        private CompletionResponse? CompletionResponseMessage;

        /// <summary>
        /// Read the response, check if result was succesfull, convert to string instead of JSON object and return the first choice from chatGPT.
        /// </summary>
        /// <returns></returns>
        public async Task<string?> GetCompletionResponseAsync()
        {

            if (HttpResponseMessage != null)
            {
                if (HttpResponseMessage.IsSuccessStatusCode)
                {
                    string responseString = await HttpResponseMessage.Content.ReadAsStringAsync();
                    {
                        if (!string.IsNullOrWhiteSpace(responseString))
                        {
                            CompletionResponseMessage = JsonSerializer.Deserialize<CompletionResponse>(responseString);
                        }
                    }
                }
                else
                {
                    return HttpResponseMessage?.ReasonPhrase ?? "ERROR";
                }
            }
            if (CompletionResponseMessage != null)
            {
                return CompletionResponseMessage.Choices?[0]?.Text;
            }
            return "";
        }
    }
}
