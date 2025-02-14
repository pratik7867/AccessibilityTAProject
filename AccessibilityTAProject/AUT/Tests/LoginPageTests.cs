using NUnit.Framework;
using AccessibilityTAProject.BaseTest;
using AccessibilityTAProject.Utilities.AxeCoreUtilities;
using AccessibilityTAProject.AUT.POM;

namespace AccessibilityTAProject
{
    [TestFixture]
    public class LoginPageTests : BaseTestPlatter
    {
        [Test]
        public void LoginPage_Analyze_With_WCAG21RuleSet()
        {
            LandingPage.GetInstance(WebDriver)
                .WaitUntilNavBarDisplayed();

            NavigationBarPage.GetInstance(WebDriver)
                .NavigateToLoginPage();

            // Axe analysis and report generation
            AxeResult = AxeBuilder.Exclude("#logInModal > .modal-dialog[role=\"document\"] > .modal-content").Analyze();
            AxeReportGenerator.CreateResultsOutput(AxeResult, TestContext.CurrentContext.Test.MethodName);
            AxeResultDictionary.Add(TestContext.CurrentContext.Test.MethodName, AxeResult);
        }
    }
}
