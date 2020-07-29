using OpenQA.Selenium;
using SeleniumTasks.Core;
using SeleniumTasks.Pages.DemoQA;

namespace SeleniumTasks.Pages
{
    public class TooltipsPage : DemoQAPage
    {
        public TooltipsPage(WebDriver driver) 
            : base(driver)
        {
        }

        public WebElement TextInput => Driver.FindElement(By.XPath("//*[@id='toolTipTextField']"));

        public WebElement ToolTipPopup => Driver.FindElement(By.XPath("//*[@id='textFieldToolTip']//div[(@class='tooltip-inner')]"));

        public void HoverToolTip()
        {
            Builder.MoveToElement(TextInput.WrappedElement).Perform();
        }
    }
}