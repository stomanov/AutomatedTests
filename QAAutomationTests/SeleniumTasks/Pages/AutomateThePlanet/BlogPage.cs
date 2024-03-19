using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using SeleniumProject.BaseProject;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.AutomateThePlanet
{
    public class BlogPage : BasePage
    {
        public BlogPage(WebDriver driver) : base(driver) { }

        public List<WebElement> Articles => Driver.FindElements(By.XPath("//*[@class='so-panel widget widget_categorylist']//article")).ToList();
    }
}