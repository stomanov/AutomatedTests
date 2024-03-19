using OpenQA.Selenium.Interactions;

namespace SeleniumProject.BaseProject
{
    public partial class BasePage
    {
        public BasePage(WebDriver driver)
        {
            Driver = driver;
            Builder = new Actions(driver.WrappedDriver);
        }

        public virtual string URL { get; }

        protected WebDriver Driver { get; }

        protected Actions Builder { get; }
    }
}