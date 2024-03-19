using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace SeleniumProject.BaseProject
{
    public class WebDriver
    {
        public IWebDriver WrappedDriver { get; set; }

        public IWait<IWebDriver> Wait { get; set; }

        public void TakeScreenshot(string relativePath = @"..\..\..\")
        {
            string dirPath = Path.GetFullPath(@relativePath, Directory.GetCurrentDirectory());
            string testName = TestContext.CurrentContext.Test.Name.Replace("\"", "");
            Screenshot screenshot = ((ITakesScreenshot)WrappedDriver).GetScreenshot();
            screenshot.SaveAsFile($"{dirPath}\\Screenshots\\{testName}_{DateTime.Now:ddMMyy-HH_mm}.png");
        }

        public IWebDriver GetIWebDriver()
        {
            return WrappedDriver;
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
            IWebElement nativeWebElement = Wait.Until(d => d.FindElement(locator));
            WebElement element = new(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindExistingElement(By locator)
        {
            IWebElement nativeWebElement = Wait.Until(ExpectedConditions.ElementExists(locator));
            WebElement element = new(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindClickableElement(By locator)
        {
            IWebElement nativeWebElement = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            WebElement element = new(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public WebElement FindVisibleElement(By locator)
        {
            IWebElement nativeWebElement = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            WebElement element = new(WrappedDriver, nativeWebElement, locator);

            return element;
        }

        public List<WebElement> FindElements(By locator)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));

            var elements = new List<WebElement>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                WebElement element = new(WrappedDriver, nativeWebElement, locator);
                elements.Add(element);
            }

            return elements;
        }

        public void WaitForElementToBecomeInvisible(By locator)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitForStalenessOfElement(WebElement element)
        {
            Wait.Until(ExpectedConditions.StalenessOf(element.WrappedElement));
        }

        public void WaitForTextToBePresentInElement(WebElement element, string text)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElement(element.WrappedElement, text));
        }
    }
}