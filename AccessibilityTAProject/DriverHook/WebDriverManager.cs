using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AccessibilityTAProject.DriverHook
{
    public abstract class WebDriverManager
    {
        public enum BrowserType
        {
            Chrome,
        }

        private static readonly ThreadLocal<IWebDriver> threadLocalDriver = new ThreadLocal<IWebDriver>();

        public IWebDriver GetWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    threadLocalDriver.Value = new ChromeDriver();
                    break;
                default:
                    throw new Exception("Invalid browser type");
            }

            return threadLocalDriver.Value;
        }

        public void CloseWebDriver()
        {
            if (threadLocalDriver.Value != null)
            {
                threadLocalDriver.Value.Quit();
                threadLocalDriver.Value = null;
            }
        }
    }
}
