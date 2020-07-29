using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages
{
    public class BasePage
    {
        public BasePage(WebDriver driver)
        {
            Driver = driver;
            Builder = new Actions(driver.WrappedDriver);
        }

        public virtual string URL { get; }

        public WebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        protected Actions Builder { get; set; }

        public void ScrollTo(WebElement element)
        {
            ((IJavaScriptExecutor)Driver.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
        }

        public void ScrollUp(int offset)
        {
            ((IJavaScriptExecutor)Driver.WrappedDriver).ExecuteScript($"window.scrollBy(0, -{offset});");
        }

        public void ScrollDown(int offset)
        {
            ((IJavaScriptExecutor)Driver.WrappedDriver).ExecuteScript($"window.scrollBy(0, {offset});");
        }
    }
}