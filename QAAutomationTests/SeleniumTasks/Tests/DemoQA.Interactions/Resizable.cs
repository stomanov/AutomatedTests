using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;
using SeleniumProject.Pages.DemoQA.ResizablePage;

namespace SeleniumProject.Tests.DemoQA.Interactions
{
    class Resizable : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private ResizablePage resizablePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            resizablePage = new ResizablePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Interactions").WaitAndClick();
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Resizable")).WaitAndClick();
            resizablePage.ScrollUp(100);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void BoxReachedLimit_When_Resized()
        {
            var resizableLimitedBoxValueBefore = resizablePage.resizableLimitedBox.GetAttribute("style");

            Builder.DragAndDropToOffset(resizablePage.resizableLimitedBoxCorner.WrappedElement, 300, 100).Perform();

            var resizableLimitedBoxValueAfter = resizablePage.resizableLimitedBox.GetAttribute("style");

            resizablePage.AssertDimensionsBefore("width: 200px; height: 200px;", resizableLimitedBoxValueBefore);
            resizablePage.AssertDimensionsAfter("width: 500px; height: 300px;", resizableLimitedBoxValueAfter);
        }

        [Test]
        public void BoxReachedMinimumLimit_When_Resized()
        {
            var resizableUnlimitedBoxValueBefore = resizablePage.resizableUnlimitedBox.GetAttribute("style");

            Builder.DragAndDropToOffset(resizablePage.resizableUnlimitedBoxCorner.WrappedElement, -200, -200).Perform();

            var resizableUnlimitedBoxValueAfter = resizablePage.resizableUnlimitedBox.GetAttribute("style");

            resizablePage.AssertDimensionsBefore("width: 200px; height: 200px;", resizableUnlimitedBoxValueBefore);
            resizablePage.AssertDimensionsAfter("width: 20px; height: 20px;", resizableUnlimitedBoxValueAfter);
        }
    }
}