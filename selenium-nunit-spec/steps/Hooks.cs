using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_nunit_spec.config;
using System;
using TechTalk.SpecFlow;

namespace selenium_nunit_spec.steps
{
    class Hooks : CommonSteps
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public Hooks(ScenarioContext context) : base (context)
        {
            // base(context);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\reply\source\repos\selenium-nunit-spec-solution\selenium-nunit-spec\reports\index.html");
            htmlReporter.Config.ReportName = "Demo report";
            //htmlReporter.Config.
            //htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            //scenario.Info(Status.Info,"Sample log");
            scenario.Log(Status.Pass, "passing tets");
            
            var stepType = context.StepContext.StepInfo.StepDefinitionType.ToString();
            if (context.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(context.StepContext.StepInfo.Text).Info("helo");
                else if (stepType == "When")
                    scenario.CreateNode<When>(context.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(context.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("s1.png");
                scenario.AddScreenCaptureFromPath("s1.png");

                if (stepType == "Given")
                    scenario.CreateNode<Given>(context.StepContext.StepInfo.Text).Fail(context.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(context.StepContext.StepInfo.Text).Fail(context.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(context.StepContext.StepInfo.Text).Fail(context.TestError.Message);
            }

            
        
            
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {           
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            //featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void runBeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(context.ScenarioInfo.Title);

            TestContext.Progress.WriteLine("Run before scenario");

            //context["traveldata"] = travelData;
            //var city = ((TravelData)context["traveldata"]).destinations[0];

             driver = new ChromeDriver();
             context["driver"] = driver;
            /* driver = new ChromeDriver();

             var config = ConfigManager.GetConfig();
             String wait =config["implicit-wait"];
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds( Int32.Parse(wait));

             driver.Navigate().GoToUrl("https://www.1cover.com.au/");*/
            //   context[""]
        }

        [AfterScenario]
        public void runAfterScenario()
        {
            scenario.Log(Status.Pass, "Scenario passed");
          

            //scenario.Log(Status.Pass, ss.AsBase64EncodedString);
            //scenario.AddScreenCaptureFromBase64String(ss.AsBase64EncodedString);

            TestContext.Progress.WriteLine("Run after scenario");
            driver.Quit();
        }

    }
}
