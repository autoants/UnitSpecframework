using NUnit.Framework;
using RestSharp;
using System.Net;

namespace BDDMsTestFeatureTests.API
{
    public class RESTOperations
    {
        private static RestRequest restRequest;
        private static RestClient restClient;
        

        public static RestClient SetRestClient(string baseUrl)
        {
            return restClient = new RestClient(baseUrl);
        }

        public static IRestResponse GetResourceInformation(string endpoint)
        {
            restRequest = new RestRequest(endpoint, Method.GET);
            IRestResponse response = restClient.Execute(restRequest);
            return response;
        }

        public static void AssertResponseContainsExpectedResult(IRestResponse response, string expectedResult)
        {
            if(response.StatusCode== HttpStatusCode.OK)
            {
                var resultString = response.Content;
                Assert.True(resultString.Contains(expectedResult));
            }
        }
        
    }
}
