using System.Linq;
using OpenQA.Selenium;

namespace AccessibilityTAProject.Utilities.WebUtilities
{
    public class NavigationUtils
    {
        private readonly IWebDriver _webDriver;

        private JSUtils jSUtils { get; set; }

        public static NavigationUtils GetInstance(IWebDriver webDriver)
        {
            return new NavigationUtils(webDriver);
        }

        private NavigationUtils(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            InitializeCommonClasses();
        }

        private void InitializeCommonClasses()
        {
            jSUtils = JSUtils.GetInstance(_webDriver);
        }

        public void NavigateToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
        }

        public void GoToFirstTab()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
        }

        public void OpenTabAndMoveToIt()
        {
            jSUtils.ExecuteScript("window.open();");
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
        }
    }
}
