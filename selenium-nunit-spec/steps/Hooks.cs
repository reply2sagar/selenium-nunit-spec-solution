﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace selenium_nunit_spec.steps
{
    class Hooks : CommonSteps
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        
        public Hooks(ScenarioContext context) : base(context)
        {
            // base(context);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"");
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
            var stepType = _context.StepContext.StepInfo.StepDefinitionType.ToString();
            if (_context.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_context.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_context.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_context.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_context.StepContext.StepInfo.Text);
            }
            else if (_context.TestError != null)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("s1.png");
                scenario.AddScreenCaptureFromPath("s1.png");

                if (stepType == "Given")
                    scenario.CreateNode<Given>(_context.StepContext.StepInfo.Text).Fail(_context.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_context.StepContext.StepInfo.Text).Fail(_context.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_context.StepContext.StepInfo.Text).Fail(_context.TestError.Message);
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
            scenario = featureName.CreateNode<Scenario>(_context.ScenarioInfo.Title);

            TestContext.Progress.WriteLine("Run before scenario");
            // _context["driver"] = new ChromeDriver();

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.1cover.com.au/");
            //   _context[""]
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
