using System;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Deque.AxeCore.Selenium;
using Deque.AxeCore.Commons;
using AccessibilityTAProject.DriverHook;
using AccessibilityTAProject.Utilities.AxeCoreUtilities;
using AccessibilityTAProject.Utilities.DataUtilities;

namespace AccessibilityTAProject.BaseTest
{
    public abstract class BaseTestPlatter : WebDriverManager
    {
        private static readonly ThreadLocal<IWebDriver> webDriver = new ThreadLocal<IWebDriver>();
        private static readonly ThreadLocal<AxeBuilder> axeBuilder = new ThreadLocal<AxeBuilder>();
        private static readonly ThreadLocal<AxeResult> axeResult = new ThreadLocal<AxeResult>();
        private static readonly ThreadLocal<Dictionary<string, AxeResult>> axeResultDictionary = new ThreadLocal<Dictionary<string, AxeResult>>(() => new Dictionary<string, AxeResult>());        

        public IWebDriver WebDriver
        {
            get => webDriver.Value;
            set => webDriver.Value = value;
        }

        public AxeBuilder AxeBuilder
        {
            get => axeBuilder.Value;
            set => axeBuilder.Value = value;
        }

        public AxeResult AxeResult
        {
            get => axeResult.Value;
            set => axeResult.Value = value;
        }

        public Dictionary<string, AxeResult> AxeResultDictionary
        {
            get => axeResultDictionary.Value;
            set => axeResultDictionary.Value = value;
        }
        

        [OneTimeSetUp]
        private string GetBrowser()
        {
            return ConfigurationManager.AppSettings["Browser"].ToString();
        }

        [SetUp]
        public void Setup()
        {
            WebDriver = GetWebDriver((BrowserType)Enum.Parse(typeof(BrowserType), GetBrowser()));
            AxeBuilder = AxeInitializer.GetInstance(WebDriver).GetAxeBuilder();
            axeResultDictionary.Value = new Dictionary<string, AxeResult>();

            Console.WriteLine($"Test: {TestContext.CurrentContext.Test.Name} has started executing...");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    var pathToFailedTestsFile = DataExtractor.GetFilePath("failedtests.txt");
                    DataWriter.AppendAllTextToFile(pathToFailedTestsFile, TestContext.CurrentContext.Test.FullName + Environment.NewLine);
                }

                foreach (var result in AxeResultDictionary)
                {
                    Assert.That(result.Value.Violations.Count, Is.EqualTo(0), $"{result.Key} has accessibility violations.");
                }
            }
            catch (Exception)
            {
                // Intentionally left blank
            }
            finally
            {
                Console.WriteLine($"Test: {TestContext.CurrentContext.Test.Name} has finished execution with Status: {TestContext.CurrentContext.Result.Outcome.Status}\n");
                CloseWebDriver();                

                // Dispose of the AxeResultDictionary
                axeResultDictionary.Value = null;
            }
        }
    }
}
