using OpenQA.Selenium;
using System.Threading;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.DemoQA
{
    public class ProgressBarPage : DemoQAPage
    {
        public ProgressBarPage(WebDriver driver) : base(driver) { }

        public WebElement StartStopButton => Driver.FindClickableElement(By.XPath("//*[@id='startStopButton']"));

        public WebElement ProgressBarValue => Driver.FindVisibleElement(By.XPath("//*[@id='progressBar']//div[(@role='progressbar')]"));

        public void StartAndThenStopProgressBar()
        {
            Thread.Sleep(400);
            StartStopButton.WaitAndClick();
            Thread.Sleep(2000);
            StartStopButton.WaitAndClick();
        }
    }
}