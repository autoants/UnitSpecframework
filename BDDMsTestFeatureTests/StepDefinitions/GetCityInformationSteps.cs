using BDDMsTestFeatureTests.API;
using BDDMsTestFeatureTests.Data;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BDDMsTestFeatureTests.StepDefinitions
{
    [Binding]
    public class GetCityInformationSteps
    {
        private RestClient restClient;
        private IRestResponse restResponse;

        [Given(@"I have the base api for us cities")]
        public void GivenIHaveTheBaseApiForUsCities(Table table)
        {
            var cityinfo = table.CreateInstance<CityInformation>();
            restClient = RESTOperations.SetRestClient(cityinfo.url);
        }

        [When(@"I request the city information using zipcode")]
        public void WhenIRequestTheCityInformationUsingZipcode(Table table)
        {
            var cityinfo = table.CreateInstance<CityInformation>();
            restResponse = RESTOperations.GetResourceInformation(cityinfo.zipcode);
        }

        [Then(@"the server returns the response with the city information")]
        public void ThenTheServerReturnsTheResponseWithTheCityInformation(Table table)
        {
            var cityinfo = table.CreateInstance<CityInformation>();
            RESTOperations.AssertResponseContainsExpectedResult(restResponse, cityinfo.city);
        }
        
    }
}
