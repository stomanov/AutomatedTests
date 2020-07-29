using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTasks.Pages.DemoQA.SortablePage
{
    public class SortablePage : BasePage
    {
        public SortablePage(WebDriver driver) : base(driver)
        {
        }

        public WebElement ListTab => Driver.FindElement(By.XPath("//*[@id='demo-tab-list']"));

        public WebElement GridTab => Driver.FindElement(By.XPath("//*[@id='demo-tab-grid']"));

        public List<WebElement> ListOfNumbers => Driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class, 'list-group-item')]")).ToList();

        public List<WebElement> GridOfNumbers => Driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//div[contains(@class, 'list-group-item')]")).ToList();

        public void AssertTextByIndexList(string expectedText, int index)
        {
            Assert.AreEqual(expectedText, ListOfNumbers[index].Text);
        }

        public void AssertTextByIndexGrid(string expectedText, int index)
        {
            Assert.AreEqual(expectedText, GridOfNumbers[index].Text);
        }
    }
}