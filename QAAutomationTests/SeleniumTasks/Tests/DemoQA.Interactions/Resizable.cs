using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;
using SeleniumTasks.Pages.DemoQA.ResizablePage;

namespace SeleniumTasks.Tests.DemoQA.Interactions
{
    class Resizable : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private ResizablePage _resizablePage;

        [SetUp]
        public void SetUp()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _resizablePage = new ResizablePage(Driver);

            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Interactions").Click();
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Resizable")).Click();
            Driver.ScrollUp(100);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TakeScreenshot(@"..\..\..\");
            }

            Driver.Quit();
        }

        [Test]
        public void BoxReachedLimit_When_Resized()
        {
            var resizableLimitedBoxValueBefore = _resizablePage.resizableLimitedBox.GetAttribute("style");

            Builder.DragAndDropToOffset(_resizablePage.resizableLimitedBoxCorner.WrappedElement, 300, 100).Perform();

            var resizableLimitedBoxValueAfter = _resizablePage.resizableLimitedBox.GetAttribute("style");

            _resizablePage.AssertDimensionsBefore("width: 200px; height: 200px;", resizableLimitedBoxValueBefore);
            _resizablePage.AssertDimensionsAfter("width: 500px; height: 300px;", resizableLimitedBoxValueAfter);
        }

        [Test]
        public void BoxReachedMinimumLimit_When_Resized()
        {
            var resizableUnlimitedBoxValueBefore = _resizablePage.resizableUnlimitedBox.GetAttribute("style");

            Builder.DragAndDropToOffset(_resizablePage.resizableUnlimitedBoxCorner.WrappedElement, -200, -200).Perform();

            var resizableUnlimitedBoxValueAfter = _resizablePage.resizableUnlimitedBox.GetAttribute("style");

            _resizablePage.AssertDimensionsBefore("width: 200px; height: 200px;", resizableUnlimitedBoxValueBefore);
            _resizablePage.AssertDimensionsAfter("width: 20px; height: 20px;", resizableUnlimitedBoxValueAfter);
        }
    }
}