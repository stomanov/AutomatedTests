using OpenQA.Selenium;
using SeleniumTasks.Core;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTasks.Pages.AutomateThePlanet
{
    public class BlogPage : BasePage
    {
        public BlogPage(WebDriver driver) 
            : base(driver)
        {
        }

        public List<WebElement> Articles => Driver.FindElements(By.XPath("//*[@class='so-panel widget widget_categorylist']//article")).ToList();
    }
}