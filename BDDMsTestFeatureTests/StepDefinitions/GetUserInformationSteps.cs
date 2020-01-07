using BDDMsTestFeatureTests.API;
using BDDMsTestFeatureTests.Data;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BDDMsTestFeatureTests.StepDefinitions
{
    [Binding]
    public class GetUserInformationSteps
    {
        private RestClient restClient;
        private IRestResponse restResponse;

        [Given(@"I have the base url")]
        public void GivenIHaveTheBaseUrl(Table table)
        {
            var userdetails = table.CreateInstance<UserInformation>();
            restClient = RESTOperations.SetRestClient(userdetails.url);
        }
        [When(@"I Request or all users in a page")]
        public void WhenIRequestOrAllUsersInAPage(Table table)
        {
            var userdetails = table.CreateInstance<UserInformation>();
            restResponse = RESTOperations.GetListOfUsers(userdetails.page);
        }
        
        [Then(@"I get user list in the given page")]
        public void ThenIGetUserListInTheGivenPage(Table table)
        {
            var userdetails = table.CreateInstance<UserInformation>();
            RESTOperations.AssertResponseContainsExpectedResult(restResponse, userdetails.page);
        }
    }
}
