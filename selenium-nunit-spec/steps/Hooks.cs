using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace selenium_nunit_spec.steps
{
    class Hooks : CommonSteps
    {
        public Hooks(ScenarioContext context) : base(context)
        {
            // base(context);
        }

        [BeforeScenario]
        public void runBeforeScenario()
        {
            TestContext.Progress.WriteLine("Run before scenario");
            // _context["driver"] = new ChromeDriver();

            driver = new ChromeDriver();
            //   _context[""]
        }

        [AfterScenario]
        public void runAfterScenario()
        {
            TestContext.Progress.WriteLine("Run after scenario");
            driver.Quit();
        }

    }
}
