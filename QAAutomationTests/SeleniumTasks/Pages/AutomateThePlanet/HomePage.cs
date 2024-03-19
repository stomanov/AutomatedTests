using OpenQA.Selenium;
using SeleniumProject.BaseProject;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.AutomateThePlanet
{ 
    public class HomePage : BasePage
    {
        public HomePage(WebDriver driver) : base(driver) { }

        public override string URL => "https://www.automatetheplanet.com/";

        public WebElement BlogButton => Driver.FindElement(By.XPath("//*[@class='menu-main-menu-container']//a[text()='Blog']"));
    }
}