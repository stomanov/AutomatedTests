using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA.PracticeForm
{
    public class PracticeFormSection : BasePage
    {
        public PracticeFormSection(WebDriver driver)
            :base(driver)
        {
        }

        public WebElement ThanksMessage => Driver.FindElement(By.XPath("//*[@id='example-modal-sizes-title-lg']"));
    }
}