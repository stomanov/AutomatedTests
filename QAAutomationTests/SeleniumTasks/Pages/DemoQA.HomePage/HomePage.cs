using OpenQA.Selenium;
using SeleniumProject.BaseProject;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.DemoQA
{
    public class HomePage : BasePage
    {
        public HomePage(WebDriver driver) : base(driver) { }

        public override string URL => "http://demoqa.com/";

        public WebElement CategoryCard(string category)
        {
            return Driver.FindExistingElement(By.XPath($"//*[normalize-space(text()) = '{category}']"));
        }
    }
}