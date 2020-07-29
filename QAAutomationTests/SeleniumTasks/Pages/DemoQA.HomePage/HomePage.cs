using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA
{
    public class HomePage : BasePage
    {
        public HomePage(WebDriver driver) : base(driver)
        {
        }

        public override string URL { get { return "http://demoqa.com/"; } }

        public WebElement CategoryCard(string category)
        {
            return Driver.FindExistingElement(By.XPath($"//*[normalize-space(text()) = '{category}']"));
        }
    }
}