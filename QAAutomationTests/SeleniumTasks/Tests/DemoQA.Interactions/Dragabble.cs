using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;
using SeleniumTasks.Pages.DemoQA.DragabblePage;

namespace SeleniumTasks.Tests.DemoQA.Interactions
{
    class Dragabble : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private DragabblePage _dragabblePage;

        [SetUp]
        public void SetUp()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _dragabblePage = new DragabblePage(Driver);

            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Interactions").Click();
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Dragabble")).Click();
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
        public void ElementChangingCoordinates_When_DragInAndOut()
        {
            Driver.ScrollToElement(_dragabblePage.SimpleTab).Click();

            Builder.DragAndDrop(_dragabblePage.DragBox.WrappedElement, _dragabblePage.OutsideDrag.WrappedElement).Perform();

            double dragPosXBefore = _dragabblePage.DragBox.Location.X;
            double dragPosYBefore = _dragabblePage.DragBox.Location.Y;

            Builder.DragAndDropToOffset(_dragabblePage.DragBox.WrappedElement, 0, -275).Perform();

            double dragPosXAfter = _dragabblePage.DragBox.Location.X;
            double dragPosYAfter = _dragabblePage.DragBox.Location.Y;

            _dragabblePage.AssertCoordinates(781, dragPosXBefore, 3);
            _dragabblePage.AssertCoordinates(569, dragPosYBefore, 3);
            _dragabblePage.AssertCoordinates(781, dragPosXAfter, 3);
            _dragabblePage.AssertCoordinates(294, dragPosYAfter, 3);
        }

        [Test]
        public void ElementsChangingCoordinatesXAndY_When_DragOnXAndOnY()
        {
            Driver.ScrollToElement(_dragabblePage.AxisTab).Click();

            double dragBoxXBefore = _dragabblePage.DragBoxX.Location.X;
            double dragBoxYBefore = _dragabblePage.DragBoxY.Location.Y;

            Builder.DragAndDrop(_dragabblePage.DragBoxX.WrappedElement, _dragabblePage.OutsideDragAxis.WrappedElement).Perform();
            Builder.DragAndDrop(_dragabblePage.DragBoxY.WrappedElement, _dragabblePage.OutsideDragAxis.WrappedElement).Perform();

            double dragBoxXAfter = _dragabblePage.DragBoxX.Location.X;
            double dragBoxYAfter = _dragabblePage.DragBoxY.Location.Y;

            _dragabblePage.AssertCoordinates(629, dragBoxXBefore, 3);
            _dragabblePage.AssertCoordinates(318, dragBoxYBefore, 3);
            _dragabblePage.AssertCoordinates(782, dragBoxXAfter, 3);
            _dragabblePage.AssertCoordinates(609, dragBoxYAfter, 3);
        }

        [Test]
        public void ElementCantDragOutsideTheBox_When_TryToDragOutside()
        {
            Driver.ScrollToElement(_dragabblePage.ContainerTab).Click();

            double textBoxXBefore = _dragabblePage.TextBox.Location.X;
            double textBoxYBefore = _dragabblePage.TextBox.Location.Y;

            Builder.DragAndDropToOffset(_dragabblePage.TextBox.WrappedElement, 562, 106).Perform();

            double textBoxXAfter = _dragabblePage.TextBox.Location.X;
            double textBoxYAfter = _dragabblePage.TextBox.Location.Y;

            _dragabblePage.AssertCoordinates(475, textBoxXBefore, 3);
            _dragabblePage.AssertCoordinates(314, textBoxYBefore, 3);
            _dragabblePage.AssertCoordinates(1037, textBoxXAfter, 3);
            _dragabblePage.AssertCoordinates(420, textBoxYAfter, 3);
        }
    }
}