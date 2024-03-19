using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.BaseProject
{
    public partial class BaseTest
    {
        protected WebDriver Driver { get; set; } = new();

        protected Actions Builder { get; set; }

        protected SelectElement Select { get; set; }

        [SetUp]
        public void BaseSetUp()
        {
            InitializeBrowser(Browser.Firefox, waitTimeValue: 20, isHeadless: false);
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success) Driver.TakeScreenshot();
            Driver.Quit();
        }
    }
}
