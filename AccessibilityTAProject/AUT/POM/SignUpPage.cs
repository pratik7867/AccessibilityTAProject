using OpenQA.Selenium;
using AccessibilityTAProject.Utilities.DataUtilities;
using AccessibilityTAProject.Utilities.WebUtilities;

namespace AccessibilityTAProject.AUT.POM
{
    public class SignUpPage
    {
        private IWebDriver _webDriver { get; set; }

        private NavigationUtils navigationUtils { get; set; }

        private WaitUtils waitUtils { get; set; } 
        
        private ElementUtils elementUtils { get; set; }

        public static SignUpPage GetInstance(IWebDriver webDriver)
        {
            return new SignUpPage(webDriver);
        }

        private SignUpPage(IWebDriver webDriver)
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

        private By userNameLocator = By.Id("sign-username");
        private By passwordLocator = By.Id("sign-password");
        private By signUpButtonLocator = By.XPath(".//button[text()='Sign up']");

        public SignUpPage EnterUserName(string userName)
        {
            waitUtils.WaitForElementToBeVisible(userNameLocator).SendKeys(userName);
            return this;
        }

        public SignUpPage EnterPassword(string password)
        {
            waitUtils.WaitForElementToBeVisible(passwordLocator).SendKeys(password);
            return this;
        }

        public SignUpPage ClickSignUp()
        {
            elementUtils.GetElement(signUpButtonLocator).Click();
            return this;
        }
    }
}
