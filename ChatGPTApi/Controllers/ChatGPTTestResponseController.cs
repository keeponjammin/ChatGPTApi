using Microsoft.AspNetCore.Mvc;
using ChatGPTApi.Models;

namespace ChatGPTApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatGPTTestResponseController
    {

        private readonly ILogger<ChatGPTTestResponseController> _logger;
        private ApiKeyModel? apiKeyRetriever;
        private HttpRequestMessageModel? requestMessage;
        private HttpResponseMessageModel? responseMessage;

        public ChatGPTTestResponseController(ILogger<ChatGPTTestResponseController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Retrieve key, store in model, create requestmessage, do call and get the needed content from the response as a string.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetChatGPTTestResponse")]
        public async Task<string?> GetAsync(string prompt = "Tell me something about yourself")
        {
            apiKeyRetriever = new ApiKeyModel{ LocationPath = "apikey.txt"};
            requestMessage = new HttpRequestMessageModel
            {
                ApiKey = apiKeyRetriever.GetApiKey(),
                Prompt = prompt,
            };

            using HttpClient httpClient = new();
            using HttpResponseMessage? httpResponse = await httpClient.SendAsync(requestMessage.GetHttpRequestMessage());
            responseMessage = new HttpResponseMessageModel { HttpResponseMessage = httpResponse };

            return await responseMessage.GetCompletionResponseAsync();
        }
    }
}
