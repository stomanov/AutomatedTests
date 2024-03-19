using OpenQA.Selenium;
using SeleniumProject.BaseProject;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.DemoQA.PracticeForm
{
    public class PracticeFormSection : BasePage
    {
        public PracticeFormSection(WebDriver driver) : base(driver) { }

        public WebElement ThanksMessage => Driver.FindElement(By.XPath("//*[@id='example-modal-sizes-title-lg']"));
    }
}