using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.AutomateThePlanet
{
    public class HomePage : BasePage
    {
        public HomePage(WebDriver driver) 
            : base(driver)
        {
        }

        public override string URL { get { return "https://www.automatetheplanet.com/"; } }

        public WebElement BlogButton => Driver.FindElement(By.XPath("//*[@class='menu-main-menu-container']//a[text()='Blog']"));
    }
}