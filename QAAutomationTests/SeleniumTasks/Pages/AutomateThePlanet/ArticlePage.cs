using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.AutomateThePlanet
{
    public class ArticlePage : BasePage
    {
        public ArticlePage(WebDriver driver) 
            : base(driver)
        {
        }

        public WebElement QuickNavigation => Driver.FindVisibleElement(By.XPath("//*[@class='tve_ct_title']"));

        public List<WebElement> NavigationMainTitles => Driver.FindElements(By.XPath("//*[@class='tve_ct_level0']")).ToList();

        public List<WebElement> NavigationSecondaryTitles => Driver.FindElements(By.XPath("//*[@class='tve_ct_level1']")).ToList();

        public List<WebElement> MainHeaders => Driver.FindElements(By.XPath("//*[@id='tve_flt']//h2")).ToList();

        public List<WebElement> SecondaryHeaders => Driver.FindElements(By.XPath("//*[@id='tve_flt']//h3")).ToList();
    }
}