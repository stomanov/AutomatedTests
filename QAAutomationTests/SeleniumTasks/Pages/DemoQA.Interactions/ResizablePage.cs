using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA.ResizablePage
{
    public class ResizablePage : BasePage
    {
        public ResizablePage(WebDriver driver) : base (driver)
        {
        }

        public WebElement resizableLimitedBox => Driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']"));
        
        public WebElement resizableUnlimitedBox => Driver.FindElement(By.XPath("//*[@id='resizable']"));

        public WebElement resizableLimitedBoxCorner => Driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));

        public WebElement resizableUnlimitedBoxCorner => Driver.FindElement(By.XPath("//*[@id='resizable']/span"));

        public void AssertDimensionsBefore(string dimensionsInPixelsBefore, string dimensionsBefore)
        {
            Assert.AreEqual(dimensionsInPixelsBefore, dimensionsBefore);
        }

        public void AssertDimensionsAfter(string dimensionsInPixelsAfter, string dimensionsAfter)
        {
            Assert.AreEqual(dimensionsInPixelsAfter, dimensionsAfter);
        }
    }
}