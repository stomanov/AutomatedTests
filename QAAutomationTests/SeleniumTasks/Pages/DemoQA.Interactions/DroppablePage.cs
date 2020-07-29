using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA.DroppablePage
{
    public class DroppablePage : BasePage
    {
        public DroppablePage(WebDriver driver) : base (driver)
        {
        }

        public WebElement SourceBox => Driver.FindExistingElement(By.XPath("//*[@id='draggable']"));

        public WebElement TargetBox => Driver.FindExistingElement(By.XPath("//*[@id='droppable']"));

        public WebElement SimpleTab => Driver.FindElement(By.XPath("//*[@id='droppableExample-tab-simple']"));

        public void AssertColorsBeforeAndAfter(string colorBefore, string colorAfter)
        {
            Assert.AreNotEqual(colorBefore, colorAfter);
        }

        public void AssertCoordinates(double coordinatesX1, double coordinatesX2, double roundingCoordinates)
        {
            Assert.AreEqual(coordinatesX1, coordinatesX2, roundingCoordinates);
        }
    }
}