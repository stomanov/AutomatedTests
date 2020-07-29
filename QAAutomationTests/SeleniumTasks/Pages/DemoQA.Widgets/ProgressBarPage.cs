using OpenQA.Selenium;
using SeleniumTasks.Core;
using System.Threading;

namespace SeleniumTasks.Pages.DemoQA
{
    public class ProgressBarPage : DemoQAPage
    {
        public ProgressBarPage(WebDriver driver) : base(driver)
        {
        }

        public WebElement StartStopButton => Driver.FindClickableElement(By.XPath("//*[@id='startStopButton']"));

        public WebElement ProgressBarValue => Driver.FindVisibleElement(By.XPath("//*[@id='progressBar']//div[(@role='progressbar')]"));

        public void StartAndThenStopProgressBar()
        {
            Thread.Sleep(400);
            StartStopButton.Click();
            Thread.Sleep(1880);
            StartStopButton.Click();
        }
    }
}