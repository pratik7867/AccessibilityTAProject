using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AccessibilityTAProject.Utilities.WebUtilities
{
    public class ActionUtils
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _actions;

        private ActionUtils(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _actions = new Actions(_webDriver);
        }

        public static ActionUtils GetInstance(IWebDriver _webDriver)
        {
            return new ActionUtils(_webDriver);
        }

        public void MoveToElement(IWebElement element)
        {
            _actions.MoveToElement(element).Perform();
        }

        public void MoveByOffSet(int x, int y)
        {
            _actions.MoveByOffset(x, y).Perform();
        }

        public void ClickAndHold(IWebElement element)
        {
            _actions.ClickAndHold(element).Perform();
        }
    }
}
