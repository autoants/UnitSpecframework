using BDDMsTestFeatureTests.BaseConfig;
using BDDMsTestFeatureTests.Data;
using BDDMsTestFeatureTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDMsTestFeatureTests.Hooks
{
    [Binding]
    public sealed class PreRequisites : TestBase
    {
        
        protected static AccountOverViewPage accountServicePage { get; set; }
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario]
        public static void InitDriver()
        {            
            if (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("API"))
            {

                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://parabank.parasoft.com");
                accountServicePage = new AccountOverViewPage(_driver);
            }
                                        
        }

        [BeforeScenario("Login")]
        public void BeforeScenarioLogin()
        {
            //TODO: implement logic that has to run before executing each scenario
            var registrationPage = new RegistrationPage(_driver);
            registrationPage.NavigateToRegistrationPage();
            var userInfo = new UserDto();
            var usercredentials = new UserInformation();
            registrationPage.EnterUserInformation(userInfo.FirstName, userInfo.LastName, userInfo.Street,userInfo.City, userInfo.State, userInfo.Zip, userInfo.Phone, userInfo.SSN, userInfo.Uname, userInfo.PassWord, userInfo.PassWord);
            registrationPage.SubmitRegistration();
            registrationPage.ConfirmRegistration(userInfo.Uname);
            registrationPage.LogOut();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                //TODO: implement logic that has to run after executing each scenario
                _driver.Close();
            }
                
        }
    }
}
