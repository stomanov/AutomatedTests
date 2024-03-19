using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;

namespace SeleniumProject.BaseProject
{
    public partial class BaseTest
    {
        /// <summary>
        /// Initialize Browser
        /// </summary>
        /// <param name="browser">Browser type - Google Chrome, Mozilla Firefox, Microsoft Edge</param>
        /// <param name="waitTimeValue">The time duration that explicit wait will use [default - 10 sec]</param>
        /// <param name="isHeadless">If the browser should open a window or should works at the backgroud [default - true]</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void InitializeBrowser(Browser browser, double waitTimeValue = 10, bool isHeadless = true)
        {
            Driver.WrappedDriver = browser switch
            {
                Browser.Chrome => new ChromeDriver(Environment.CurrentDirectory, ChromeOptions(isHeadless)),
                Browser.Firefox => new FirefoxDriver(Environment.CurrentDirectory, FirefoxOptions(isHeadless)),
                Browser.Edge => new EdgeDriver(Environment.CurrentDirectory, EdgeOptions(isHeadless)),
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, null)
            };

            Driver.GetIWebDriver().Manage().Window.Size = new Size(1920, 1080);
            Driver.Wait = new WebDriverWait(Driver.GetIWebDriver(), TimeSpan.FromSeconds(waitTimeValue));
            Builder = new Actions(Driver.WrappedDriver);
        }

        private ChromeOptions ChromeOptions(bool isHeadless)
        {
            ChromeOptions chromeOptions = new();
            if (isHeadless) chromeOptions.AddArguments("--disable-gpu", "--headless");
            chromeOptions.AddArgument("--disable-features=VizDisplayCompositor");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--no-sandbox");
            return chromeOptions;
        }

        private FirefoxOptions FirefoxOptions(bool isHeadless)
        {
            FirefoxOptions firefoxOptions = new();
            if (isHeadless) firefoxOptions.AddArgument("-headless");
            firefoxOptions.AddArgument("--no-remote");
            firefoxOptions.AddArgument("--disable-extensions");
            firefoxOptions.AddArgument("--disable-popup-blocking");
            return firefoxOptions;
        }

        private EdgeOptions EdgeOptions(bool isHeadless)
        {
            EdgeOptions edgeOptions = new();
            if (isHeadless) edgeOptions.AddArguments("--disable-gpu", "--headless");
            edgeOptions.AddArgument("--disable-features=VizDisplayCompositor");
            edgeOptions.AddArgument("--disable-dev-shm-usage");
            edgeOptions.AddArgument("--disable-extensions");
            edgeOptions.AddArgument("--disable-popup-blocking");
            edgeOptions.AddArgument("--disable-infobars");
            edgeOptions.AddArgument("--no-sandbox");
            return edgeOptions;
        }
        
    }
}
