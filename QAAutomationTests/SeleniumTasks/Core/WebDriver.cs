using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SeleniumTasks.Core
{
    public class WebDriver
    {
        private WebDriverWait _webDriverWait;

        public IWebDriver WrappedDriver { get; private set; }

        public void Start(Browser browser)
        {
            var chromeMaximized = new ChromeOptions();
            chromeMaximized.AddArgument("start-maximized");

            var chromeHeadless = new ChromeOptions();
            chromeHeadless.AddArguments("--window-size=1200,900", "--headless");

            WrappedDriver = browser switch
            {
                Browser.Chrome => new ChromeDriver(Environment.CurrentDirectory),
                Browser.ChromeMaximized => new ChromeDriver(Environment.CurrentDirectory, chromeMaximized),
                Browser.ChromeHeadless => new ChromeDriver(Environment.CurrentDirectory, chromeHeadless),
                Browser.Firefox => new FirefoxDriver(Environment.CurrentDirectory),
                Browser.Edge => new EdgeDriver(Environment.CurrentDirectory),
                Browser.Opera => new OperaDriver(Environment.CurrentDirectory),
                Browser.Safari => new SafariDriver(Environment.CurrentDirectory),
                Browser.InternetExplorer => new InternetExplorerDriver(Environment.CurrentDirectory),
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, null),
            };
            _webDriverWait = new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(32));
        }

        public void Quit()
        {
            WrappedDriver.Quit();
        }

        public void NavigateTo(string url)
        {
            WrappedDriver.Navigate().GoToUrl(url);
        }

        public string PageSource()
        {
            return WrappedDriver.PageSource;
        }

        public string Url()
        {
            return WrappedDriver.Url;
        }

        public string Title()
        {
            return WrappedDriver.Title;
        }

        public void ConvertToString()
        {
            WrappedDriver.ToString();
        }

        public WebElement FindElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(d => d.FindElement(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindExistingElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindClickableElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindVisibleElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public List<WebElement> FindElements(By locator)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));

            var elements = new List<WebElement>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                WebElement element = new WebElement(WrappedDriver, nativeWebElement, locator);
                elements.Add(element);
            }

            return elements;
        }

        public void WaitForElementToBecomeInvisible(By locator)
        {
            _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitForStalenessOfElement(WebElement element)
        {
            _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element.WrappedElement));
        }

        public void WaitForTextToBePresentInElement(WebElement element, string text)
        {
            _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element.WrappedElement, text));
        }
    }
}