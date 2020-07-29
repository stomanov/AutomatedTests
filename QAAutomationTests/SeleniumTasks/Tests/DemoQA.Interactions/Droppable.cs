using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;
using SeleniumTasks.Pages.DemoQA.DroppablePage;

namespace SeleniumTasks.Tests.DemoQA.Interactions
{
    class Droppable : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private DroppablePage _droppablePage;

        [SetUp]
        public void SetUp()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _droppablePage = new DroppablePage(Driver);

            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Interactions").Click();
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Droppable")).Click();
            Driver.ScrollToElement(_droppablePage.SimpleTab).Click();
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
        public void TargetBoxColorIsChanged_When_ElementIsDraggedAndDroppedInsideAndThenOutside()
        {
            var colorBefore = _droppablePage.TargetBox.WrappedElement.GetCssColor();

            Builder.DragAndDrop(_droppablePage.SourceBox.WrappedElement, _droppablePage.TargetBox.WrappedElement).DragAndDropToOffset(_droppablePage.SourceBox.WrappedElement, 0, 180).Perform();

            var colorAfter = _droppablePage.TargetBox.WrappedElement.GetCssColor();

            _droppablePage.AssertColorsBeforeAndAfter(colorAfter, colorBefore);
        }

        [Test]
        public void TargetBoxColorIsChanged_When_ElementIsDraggedAndDroppedInside()
        {
            var colorBefore = _droppablePage.TargetBox.WrappedElement.GetCssColor();

            Builder.DragAndDrop(_droppablePage.SourceBox.WrappedElement, _droppablePage.TargetBox.WrappedElement).Perform();

            var colorAfter = _droppablePage.TargetBox.WrappedElement.GetCssColor();

            _droppablePage.AssertColorsBeforeAndAfter(colorAfter, colorBefore);
        }

        [Test]
        public void SourceBoxCoordinatesChanged_When_DragAndDropped()
        {
            double sourcePosXBefore = _droppablePage.SourceBox.Location.X;
            double sourcePosYBefore = _droppablePage.SourceBox.Location.Y;

            Builder.DragAndDropToOffset(_droppablePage.SourceBox.WrappedElement, 200, 150).Perform();

            double sourcePosXAfter = _droppablePage.SourceBox.Location.X;
            double sourcePosYAfter = _droppablePage.SourceBox.Location.Y;

            _droppablePage.AssertCoordinates(612, sourcePosXBefore, 3);
            _droppablePage.AssertCoordinates(302, sourcePosYBefore, 3);
            _droppablePage.AssertCoordinates(812, sourcePosXAfter, 3);
            _droppablePage.AssertCoordinates(452, sourcePosYAfter, 3);
        }
    }
}