using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumTasks.Core;
using System;
using System.IO;
using System.Threading;

namespace SeleniumTasks
{
    [TestFixture]
    public class BaseTest
    {
        protected WebDriver Driver { get; set; }

        protected Actions Builder { get; set; }

        protected SelectElement Select { get; set; }

        protected IJavaScriptExecutor JS { get; set; }

        public void InitializeMaximizedBrowser()
        {
            Driver = new WebDriver();
            Driver.Start(Browser.ChromeMaximized);
            Builder = new Actions(Driver.WrappedDriver);
            JS = (IJavaScriptExecutor)Driver.WrappedDriver;
        }

        public void InitializeHeadlessChromeBrowser()
        {
            Driver = new WebDriver();
            Driver.Start(Browser.ChromeHeadless);
            Builder = new Actions(Driver.WrappedDriver);
            JS = (IJavaScriptExecutor)Driver.WrappedDriver;
        }

        public void TakeScreenshot(string relativePath)
        {
            string dirPath = Path.GetFullPath(@relativePath, Directory.GetCurrentDirectory());
            Thread.Sleep(500);
            var screenshot = ((ITakesScreenshot)Driver.WrappedDriver).GetScreenshot();
            string testName = TestContext.CurrentContext.Test.Name.Replace("\"", "");
            screenshot.SaveAsFile($"{dirPath}\\Screenshots\\{testName}_{DateTime.Now:ddMMyy-HH_mm}.png", ScreenshotImageFormat.Png);
        }
    }
}