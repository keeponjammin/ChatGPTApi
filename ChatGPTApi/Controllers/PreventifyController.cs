using ChatGPTApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PreventifyController : Controller
    {

        private readonly ILogger<PreventifyController> _logger;
        private ApiKeyModel? apiKeyRetriever;
        private HttpRequestMessageModel? requestMessage;
        private HttpResponseMessageModel? responseMessage;

        public PreventifyController(ILogger<PreventifyController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// age, gender, children, type of work, personal additional stuff
        /// Retrieve key, store in model, create requestmessage, do call and get the needed content from the response as a string.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetPreventifyContext")]
        public async Task<string?> GetAsync(int age, bool hasChildren, string typeOfWork, string description, string gender)
        {
            apiKeyRetriever = new ApiKeyModel { LocationPath = "apikey.txt" };
            requestMessage = new HttpRequestMessageModel
            {
                ApiKey = apiKeyRetriever.GetApiKey(),
            };

            using HttpClient httpClient = new();
            using HttpResponseMessage? httpResponse = await httpClient.SendAsync(requestMessage.GetHttpRequestMessage(age, hasChildren, typeOfWork, description, gender));
            responseMessage = new HttpResponseMessageModel { HttpResponseMessage = httpResponse };

            return await responseMessage.GetCompletionResponseAsync();
        }
    }
}
