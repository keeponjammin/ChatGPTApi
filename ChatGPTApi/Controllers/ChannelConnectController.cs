using ChatGPTApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChannelConnectController : Controller
    {
        private readonly ILogger<ChannelConnectController> _logger;
        private ApiKeyModel? apiKeyRetriever;
        private HttpRequestMessageModel? requestMessage;
        private HttpResponseMessageModel? responseMessage;

        public ChannelConnectController(ILogger<ChannelConnectController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetChannelConnect")]
        public async Task<string?> GetAsync(int age, bool hasChildren, string typeOfWork, string gender, string description)
        {
            apiKeyRetriever = new ApiKeyModel { LocationPath = "apikey.txt" };
            requestMessage = new HttpRequestMessageModel
            {
                ApiKey = apiKeyRetriever.GetApiKey(),
            };

            using HttpClient httpClient = new();
            using HttpResponseMessage? httpResponse = await httpClient.SendAsync(requestMessage.GetHttpRequestMessage(age, hasChildren, typeOfWork, description, gender, true));
            responseMessage = new HttpResponseMessageModel { HttpResponseMessage = httpResponse };

            return await responseMessage.GetCompletionResponseAsync();
        }
    }
}
