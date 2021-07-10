using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_nunit_spec.models;
using selenium_nunit_spec.page_object_models;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

//extent report
//working code


namespace selenium_nunit_spec
{
    [Binding]
    public class SpecFlowFeature1Steps : CommonSteps
    {
        public SpecFlowFeature1Steps(ScenarioContext context) : base(context)
        {
            
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            // ScenarioCont.Current.Pending();
        }

        [Then(@"error should be displayed")]
        public void ThenErrorShouldBeDisplayed()
        {
            //Assert.IsTrue(1 == 2);
        }


        [Given(@"I entered the following data into the new account form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewAccountForm(Table table)
        {
            var account = table.CreateInstance<Account>();

        }

        [Given(@"I entered the following data into the new travel form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewTravelForm(Table table)
        {
            //using System.Configuration
            //var appSettings = ConfigurationManager.AppSettings;

            

            var planPage = new PlanPage(driver);
            //planPage.

            driver.Navigate().GoToUrl("https://www.1cover.com.au/");

            //config["SMTP:host"]
            var connectionString = configManager["ConnectionString"];

            //  var travelData = table.CreateInstance<TravelData>();
            //  int a = 1;
            //

            //driver.findelement

            var travelData = TravelData.getSample();
            //travelData.name = table.Rows[0].GetString("value");
            
            context["traveldata"] = travelData;
            //travelData.returnDate = new DateTime().AddDays(-2);
            // travelData.destinations = new List<String> { "australia","india" };


            // - removes duplication
            // - verification - state of application/ state of scenario

            //ScenarioContext["j"] = "";
            //= new List<string> { "Bali"};

            //public List<String> destinations;
            //public DateTime departureDate;
            //public DateTime returnDate;
            //public List<int> ages;

            //destinationInputbox.sendkeys('bali')
            //departureDate.SendKeys("22/07/2021")
            //returnDate.SendKeys("22/08/2021")

        }

        [Given(@"I call this")]
        public void GivenICallThis()
        {
            int b = 0;
           // ScenarioContext.Current.Pending();
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }

       

    }
}
