using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_nunit_spec.config;
using System;
using TechTalk.SpecFlow;

namespace selenium_nunit_spec
{
    [Binding]
    public class CommonSteps
    {

        protected ScenarioContext context;
        protected IWebDriver driver;
        protected IConfigurationRoot configManager;
        public CommonSteps(ScenarioContext context) {
            configManager = ConfigManager.GetConfig();
            this.context = context;
            if (context.ContainsKey("driver"))
            driver = ((IWebDriver)context["driver"]) ;
        }

        
    }
}
