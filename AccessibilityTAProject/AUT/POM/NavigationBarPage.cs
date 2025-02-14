using OpenQA.Selenium;
using AccessibilityTAProject.Utilities.DataUtilities;
using AccessibilityTAProject.Utilities.WebUtilities;

namespace AccessibilityTAProject.AUT.POM
{
    public class NavigationBarPage
    {
        private IWebDriver _webDriver { get; set; }

        private NavigationUtils navigationUtils { get; set; }

        private WaitUtils waitUtils { get; set; }        

        public static NavigationBarPage GetInstance(IWebDriver webDriver)
        {
            return new NavigationBarPage(webDriver);
        }

        private NavigationBarPage(IWebDriver webDriver)
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

        private By contactTabLocator = By.XPath(".//a[text()='Contact']");
        private By aboutUsTabLocator = By.XPath(".//a[text()='About us']");
        private By loginTabLocator = By.Id("login2");
        private By signUpTabLocator = By.Id("signin2");

        public NavigationBarPage NavigateToContactPage()
        {
            waitUtils.WaitForElementToBeClickable(contactTabLocator).Click();
            return this;
        }

        public NavigationBarPage NavigateToAboutUsPage()
        {
            waitUtils.WaitForElementToBeClickable(aboutUsTabLocator).Click();
            return this;
        }

        public NavigationBarPage NavigateToLoginPage()
        {
            waitUtils.WaitForElementToBeClickable(loginTabLocator).Click();
            return this;
        }

        public NavigationBarPage NavigateToSignUpPage()
        {
            waitUtils.WaitForElementToBeClickable(signUpTabLocator).Click();
            return this;
        }
    }
}
