using OpenQA.Selenium;

namespace AccessibilityTAProject.Utilities.WebUtilities
{
    public class JSUtils
    {
        private readonly IWebDriver _webDriver;

        private JSUtils(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public static JSUtils GetInstance(IWebDriver webDriver)
        {
            return new JSUtils(webDriver);
        }

        public object ExecuteScript(string script)
        {
            return ((IJavaScriptExecutor)_webDriver).ExecuteScript(script);
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_webDriver).ExecuteScript(script, args);
        }

        public void ScrollIntoViewById(string Id)
        {
            string javascript = "document.getElementById('" + Id + "').scrollIntoView()";
            ExecuteScript(javascript);
        }

        public void ScrollIntoView(IWebElement element)
        {
            ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
