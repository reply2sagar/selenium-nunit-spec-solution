using NUnit.Framework;
using OpenQA.Selenium;
using selenium_nunit_spec.models;
using selenium_nunit_spec.page_object_models;
using System;
using TechTalk.SpecFlow;

namespace selenium_nunit_spec.steps
{
    [Binding]
    public class SpecFlowFeature2Steps : CommonSteps
    {

        public SpecFlowFeature2Steps(ScenarioContext context) : base(context)
        {
            
        }


        [Then(@"plan page should show correct details")]
        public void ThenPlanPageShouldShowCorrectDetails()
        {
            //_context["traveldata"] = travelData;
            var city = ((TravelData)context["traveldata"]).destinations[0];
            
            
            System.Console.WriteLine($"destination should be {city}" );

            var actualDestination = new PlanPage(driver).GetDestination();
            var expectedDestination = city;

            Assert.AreEqual(expectedDestination, actualDestination, " destination not matching");

            //var text = driver.FindElement(By.XPath("//")).Text;
        }

        [Then(@"plan page should show correct travel details")]
        public void ThenPlanPageShouldShowCorrectTravelDetails()
        {
            int a = 2;
        }

    }
}
