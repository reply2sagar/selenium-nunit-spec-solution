using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace selenium_nunit_spec
{
    [Binding]
    public class CommonSteps
    {

        protected ScenarioContext _context;

        protected IWebDriver driver;
        public CommonSteps(ScenarioContext context) {
            _context = context;
        }

        
    }
}
