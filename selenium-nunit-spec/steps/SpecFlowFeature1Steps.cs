using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using selenium_nunit_spec.models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace selenium_nunit_spec
{
    [Binding]
    public class SpecFlowFeature1Steps : CommonSteps
    {

        public SpecFlowFeature1Steps(ScenarioContext context) : base(context)
        {
            // base(context);
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            // ScenarioCont.Current.Pending();
        }

        [Then(@"error should be displayed")]
        public void ThenErrorShouldBeDisplayed()
        {
            Assert.IsTrue(1 == 2);
        }


        [Given(@"I entered the following data into the new account form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewAccountForm(Table table)
        {
            var account = table.CreateInstance<Account>();

        }

        [Given(@"I entered the following data into the new travel form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewTravelForm(Table table)
        {
            //  var travelData = table.CreateInstance<TravelData>();
            //  int a = 1;
            //

            //driver.findelement
            
            var travelData = TravelData.getSample();
            _context["traveldata"] = travelData;
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
