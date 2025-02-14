using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AccessibilityTAProject.Utilities.WebUtilities
{
    public class ElementUtils
    {
        private readonly IWebDriver _webDriver;

        private ElementUtils(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public static ElementUtils GetInstance(IWebDriver webDriver)
        {
            return new ElementUtils(webDriver);
        }

        public By GetByDynamicXPath(string locator, string[] replacementArgs)
        {
            for (int index = 0; index < replacementArgs.Length; ++index)
            {
                locator = locator.Replace("{" + index.ToString() + "}", replacementArgs[index]);
            }

            return By.XPath(locator);
        }

        public IWebElement GetElement(By by)
        {
            return _webDriver.FindElement(by);
        }

        public IList<IWebElement> GetElements(By by)
        {
            return _webDriver.FindElements(by);
        }

        public SelectElement GetSelectElement(By by)
        {
            return new SelectElement(_webDriver.FindElement(by));
        }

        public SelectElement GetSelectElement(IWebElement element)
        {
            return new SelectElement(element);
        }
    }
}
