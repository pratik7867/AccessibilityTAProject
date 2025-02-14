using OpenQA.Selenium;
using AccessibilityTAProject.Utilities.DataUtilities;
using AccessibilityTAProject.Utilities.WebUtilities;

namespace AccessibilityTAProject.AUT.POM
{
    public class LandingPage
    {
        private IWebDriver _webDriver { get; set; }

        private NavigationUtils navigationUtils { get; set; }

        private WaitUtils waitUtils { get; set; }
        

        public static LandingPage GetInstance(IWebDriver webDriver)
        {
            return new LandingPage(webDriver);
        }

        private LandingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            InitializeCommonClasses();
            navigationUtils.NavigateToUrl(DataExtractor.GetAppConfigData("AppUrl"));
            waitUtils.WaitForPageToLoad();
        }

        private void InitializeCommonClasses()
        {
            navigationUtils = NavigationUtils.GetInstance(_webDriver);
            waitUtils = WaitUtils.GetInstance(_webDriver);            
        }

        private By navigationBarLocator = By.Id("navbarExample");

        public LandingPage WaitUntilNavBarDisplayed()
        {
            waitUtils.WaitForElementToBeVisible(navigationBarLocator);
            return this;
        }
    }
}
