using OpenQA.Selenium;
using AccessibilityTAProject.Utilities.DataUtilities;
using AccessibilityTAProject.Utilities.WebUtilities;

namespace AccessibilityTAProject.AUT.POM
{
    public class LoginPage
    {
        private IWebDriver _webDriver { get; set; }

        private NavigationUtils navigationUtils { get; set; }

        private WaitUtils waitUtils { get; set; }

        private ElementUtils elementUtils { get; set; }

        public static LoginPage GetInstance(IWebDriver webDriver)
        {
            return new LoginPage(webDriver);
        }

        private LoginPage(IWebDriver webDriver)
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
            elementUtils = ElementUtils.GetInstance(_webDriver);
        }

        private By userNameLocator = By.Id("loginusername");
        private By passwordLocator = By.Id("loginpassword");
        private By logInButtonLocator = By.XPath(".//button[text()='Sign up']");

        public LoginPage EnterUserName(string userName)
        {
            waitUtils.WaitForElementToBeVisible(userNameLocator).SendKeys(userName);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            waitUtils.WaitForElementToBeVisible(passwordLocator).SendKeys(password);
            return this;
        }

        public LoginPage ClickSignUp()
        {
            elementUtils.GetElement(logInButtonLocator).Click();
            return this;
        }

    }
}
