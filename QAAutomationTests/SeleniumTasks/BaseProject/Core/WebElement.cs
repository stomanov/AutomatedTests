using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;

namespace SeleniumProject.BaseProject
{
    public class WebElement
    {
        public IWebDriver WrappedDriver { get; }

        public IWebElement WrappedElement { get; }

        public By By { get; }

        private IWait<IWebDriver> Wait { get; }

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by, double waitTimeValue = 20)
        {
            WrappedDriver = webDriver;
            WrappedElement = webElement;
            By = by;
            Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeValue));
        }

        public string Text => WrappedElement?.Text;

        public string TagName => WrappedElement?.TagName;

        public bool? Enabled => WrappedElement?.Enabled;

        public bool? Displayed => WrappedElement?.Displayed;

        public bool? Selected => WrappedElement?.Selected;

        public Size Size => WrappedElement.Size;

        public Point Location => WrappedElement.Location;

        public void FillText(string text)
        {
            Debug.WriteLine($"Text {text} is written in element with locator {By}");
            WrappedElement.SendKeys(text);
        }

        public void WaitAndClick()
        {
            WaitToBeClickable(By);
            WrappedElement?.Click();
        }

        public void Clear()
        {
            WrappedElement.Clear();
        }

        public void ClearAndFillText(string text)
        {
            Debug.WriteLine($"Text {text} is written in element with locator {By}");
            WrappedElement.Clear();
            WrappedElement.SendKeys(text);
        }

        public void ConvertToString()
        {
            WrappedElement?.ToString();
        }

        public string GetAttribute(string attributeName)
        {
            return WrappedElement?.GetAttribute(attributeName);
        }

        public string GetCssValue(string cssAttribute)
        {
            return WrappedElement?.GetCssValue(cssAttribute);
        }

        public WebElement FindElement(By by)
        {
            IWebElement nativeWebElement = Wait.Until(d => d.FindElement(by));
            return new WebElement(WrappedDriver, nativeWebElement, by);
        }

        public WebElement FindExistingElement(By by)
        {
            IWebElement nativeWebElement = Wait.Until(ExpectedConditions.ElementExists(by));
            return new WebElement(WrappedDriver, nativeWebElement, by);
        }

        public WebElement FindClickableElement(By by)
        {
            IWebElement nativeWebElement = Wait.Until(ExpectedConditions.ElementToBeClickable(by));
            return new WebElement(WrappedDriver, nativeWebElement, by);
        }

        public WebElement FindVisibleElement(By by)
        {
            IWebElement nativeWebElement = Wait.Until(ExpectedConditions.ElementIsVisible(by));
            return new WebElement(WrappedDriver, nativeWebElement, by);
        }

        public List<WebElement> FindElements(By by)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            List<WebElement> elements = new List<WebElement>();

            foreach (var nativeWebElement in nativeWebElements)
                elements.Add(new WebElement(WrappedDriver, nativeWebElement, by));
            return elements;
        }

        private void WaitToBeClickable(By by)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}