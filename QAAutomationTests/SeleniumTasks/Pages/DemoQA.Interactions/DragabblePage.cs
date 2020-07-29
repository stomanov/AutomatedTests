using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA.DragabblePage
{
    public class DragabblePage : BasePage
    {
        public DragabblePage(WebDriver driver) : base (driver)
        {
        }

        public WebElement SimpleTab => Driver.FindElement(By.XPath("//*[@id='draggableExample-tab-simple']"));

        public WebElement AxisTab => Driver.FindElement(By.XPath("//*[@id='draggableExample-tab-axisRestriction']"));

        public WebElement ContainerTab => Driver.FindElement(By.XPath("//*[@id='draggableExample-tab-containerRestriction']"));

        public WebElement DragBox => Driver.FindElement(By.XPath("//*[@id='dragBox']"));

        public WebElement OutsideDrag => Driver.FindElement(By.XPath("//*[@id='botton-text-10']"));

        public WebElement DragBoxX => Driver.FindElement(By.XPath("//*[@id='restrictedX']"));

        public WebElement DragBoxY => Driver.FindElement(By.XPath("//*[@id='restrictedY']"));

        public WebElement OutsideDragAxis => Driver.FindElement(By.XPath("//*[@id='botton-text-10']"));

        public WebElement TextBox => Driver.FindElement(By.XPath("//*[@id='containmentWrapper']//div"));

        public void AssertCoordinates(double coordinatesX1, double coordinatesX2, double roundingCoordinates)
        {
            Assert.AreEqual(coordinatesX1, coordinatesX2, roundingCoordinates);
        }
    }
}