using System.Text.Json;
using System.Text;

namespace ChatGPTApi.Models
{
    public class HttpRequestMessageModel
    {
        public string? ApiKey { get; set; }
        public string? Prompt { get; set; }

        public DiseaseListModel? DiseaseList { get; set; }

        public HttpRequestMessage GetHttpRequestMessage() 
        {
            CompletionRequest completionRequest = new()
            {
                Prompt = Prompt,
            };

            if(DiseaseList != null)
            {
                completionRequest.Prompt = $"Give me a list of the most common diseases for someone who is {DiseaseList.Age} years old, working as {DiseaseList.TypeOfWork}, {DiseaseList.HasChildrenString} children Describes himself as {DiseaseList.Description}. Take these diseases and create a list of 10 tips to prevent these diseases without naming the diseases. Keep it general. Also add an introduction, make a viral title that makes people curious.";
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions");
            httpRequestMessage.Headers.Add("Authorization", $"Bearer {ApiKey}");
            string requestString = JsonSerializer.Serialize(completionRequest);
            httpRequestMessage.Content = new StringContent(requestString, Encoding.UTF8, "application/json");

            return httpRequestMessage;
        }

        public HttpRequestMessage GetHttpRequestMessage(int age, bool hasChildren, string typeOfWork, string description)
        {
            DiseaseList = new DiseaseListModel {
                Age = age,
                HasChildren = hasChildren,
                HasChildrenString = hasChildren ? "has" : "has no",
                TypeOfWork = typeOfWork,
                Description = description,
            };

            return GetHttpRequestMessage();
        }
    }
}
