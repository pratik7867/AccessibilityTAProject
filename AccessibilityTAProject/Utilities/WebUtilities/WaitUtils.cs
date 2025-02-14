using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AccessibilityTAProject.Utilities.WebUtilities
{
    public class WaitUtils
    {
        private readonly IWebDriver _webDriver;

        private WaitUtils(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public static WaitUtils GetInstance(IWebDriver _webDriver)
        {
            return new WaitUtils(_webDriver);
        }

        public void WaitForPageToLoad(int secondsToWait = 30)
        {
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void SetImplicitWait(int secondsToWait)
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        public IWebElement WaitForElementToBePresent(By by, int secondsToWait = 20)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.ElementExists(by));
        }

        public IWebElement WaitForElementToBeVisible(By by, int secondsToWait = 20)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.ElementIsVisible(by));
        }

        public IWebElement WaitForElementToBeClickable(By by, int secondsToWait = 20)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public IWebElement WaitForElementToBeClickable(IWebElement webElement, int secondsToWait = 20)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public bool WaitForElementToBeInvisible(By by, int secondsToWait = 20)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public IList<IWebElement> WaitForElementsToBeVisible(By by, int secondsToWait = 20)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public void WaitForIframeToBeAvailableAndSwitchToIt(By by, int secondsToWait = 20)
        {
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
        }
    }
}
