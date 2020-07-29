using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA
{
    public class DemoQAPage : BasePage
    {
        public DemoQAPage(WebDriver driver) : base(driver)
        {
        }

        public WebElement PageTitle => Driver.FindExistingElement(By.XPath("//div[@class='main-header']"));
        
        public WebElement LeftPanel => Driver.FindExistingElement(By.XPath("//div[@class='accordion']"));

        public WebElement LeftPanelMenu(string menuName)
        {
            return LeftPanel.FindExistingElement(By.XPath($"//*[normalize-space(text())='{menuName}']"));
        }

        public WebElement LeftPanelSubMenu(string subMenuName)
        {
            return LeftPanel.FindExistingElement(By.XPath($"//*[normalize-space(text())='{subMenuName}']"));
        }

        public void AssertPageTitle(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, PageTitle.Text);
        }
    }
}