using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Assessment_SP
{
    public class Common
    {
        public static readonly IWebDriver _driver = new ChromeDriver();

        public static void CloseChrome()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        public bool IsElementVisible(string locator, int timeout = 0)
        {
            if (timeout != 0) WaitForVisibilityOfElement(locator, timeout);
            try
            {
                return FindElement(ByLocator(locator)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<IWebElement> GetElements(string locator, int timeout = 0)
        {
            if (timeout != 0)
                WaitForVisibilityOfElement(locator, timeout);
            IList<IWebElement> elements = _driver.FindElements(ByLocator(locator));
            return elements;
        }

        public bool ClickSpecificOptioninAList(IList<IWebElement> Options, string optionSelected)
        {
            foreach (var option in Options)
            {
                string kk = option.GetAttribute("innerText");
                if (option.GetAttribute("innerText").Equals(optionSelected))
                {
                    Console.WriteLine($"Ready to click on {optionSelected}");
                    option.Click();
                    return true;
                }
            }
            return false;
        }

        public string GetElementText(string locator, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            try
            {
                return FindElement(ByLocator(locator)).Text;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void ScrollElementIntoView(string locator, int timeout = 0)
        {
            if (_driver is IJavaScriptExecutor executor)
            {
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement(locator, timeout));
            }
        }

        public IWebElement GetElement(string locator, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            return FindElement(ByLocator(locator));
        }

        public bool WaitForVisibilityOfElement(string locator, int timeout = 0)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            try
            {
                var element = wait.Until(ExpectedConditions.ElementIsVisible(ByLocator(locator)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IWebElement FindElement(By by)
        {
            var elem = _driver.FindElement(by);
            return elem;
        }

        public By ByLocator(string locator)
        {
            var prefix = locator.Substring(0, locator.IndexOf('='));
            var suffix = locator.Substring(locator.IndexOf('=') + 1);

            switch (prefix)
            {
                case "xpath":
                    return By.XPath(suffix);
                case "css":
                    return By.CssSelector(suffix);
                case "link":
                    return By.LinkText(suffix);
                case "partLink":
                    return By.PartialLinkText(suffix);
                case "id":
                    return By.Id(suffix);
                case "name":
                    return By.Name(suffix);
                case "tag":
                    return By.TagName(suffix);
                case "class":
                    return By.ClassName(suffix);
                default:
                    return By.Id(suffix);
            }
        }
    }
}
