using NUnit.Framework;
using AccessibilityTAProject.BaseTest;
using AccessibilityTAProject.Utilities.AxeCoreUtilities;
using AccessibilityTAProject.AUT.POM;

namespace AccessibilityTAProject
{
    [TestFixture]
    public class LandingPageTests : BaseTestPlatter
    {
        [Test]
        public void LandingPage_Analyze_With_WCAG21RuleSet()
        {
            LandingPage.GetInstance(WebDriver)
                .WaitUntilNavBarDisplayed();

            // Axe analysis and report generation
            AxeResult = AxeBuilder.Analyze();
            AxeReportGenerator.CreateResultsOutput(AxeResult, TestContext.CurrentContext.Test.MethodName);
            AxeResultDictionary.Add(TestContext.CurrentContext.Test.MethodName, AxeResult);
        }
    }
}
