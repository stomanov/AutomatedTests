using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;
using SeleniumProject.Pages.DemoQA.DragabblePage;

namespace SeleniumProject.Tests.DemoQA.Interactions
{
    class Dragabble : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private DragabblePage dragabblePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            dragabblePage = new DragabblePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Interactions").WaitAndClick();
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Dragabble")).WaitAndClick();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ElementChangingCoordinates_When_DragInAndOut()
        {
            Driver.ScrollToElement(dragabblePage.SimpleTab).WaitAndClick();

            Builder.DragAndDrop(dragabblePage.DragBox.WrappedElement, dragabblePage.OutsideDrag.WrappedElement).Perform();

            double dragPosXBefore = dragabblePage.DragBox.Location.X;
            double dragPosYBefore = dragabblePage.DragBox.Location.Y;

            Builder.DragAndDropToOffset(dragabblePage.DragBox.WrappedElement, 0, -275).Perform();

            double dragPosXAfter = dragabblePage.DragBox.Location.X;
            double dragPosYAfter = dragabblePage.DragBox.Location.Y;

            dragabblePage.AssertCoordinates(781, dragPosXBefore, 3);
            dragabblePage.AssertCoordinates(569, dragPosYBefore, 3);
            dragabblePage.AssertCoordinates(781, dragPosXAfter, 3);
            dragabblePage.AssertCoordinates(294, dragPosYAfter, 3);
        }

        [Test]
        public void ElementsChangingCoordinatesXAndY_When_DragOnXAndOnY()
        {
            Driver.ScrollToElement(dragabblePage.AxisTab).WaitAndClick();

            double dragBoxXBefore = dragabblePage.DragBoxX.Location.X;
            double dragBoxYBefore = dragabblePage.DragBoxY.Location.Y;

            Builder.DragAndDrop(dragabblePage.DragBoxX.WrappedElement, dragabblePage.OutsideDragAxis.WrappedElement).Perform();
            Builder.DragAndDrop(dragabblePage.DragBoxY.WrappedElement, dragabblePage.OutsideDragAxis.WrappedElement).Perform();

            double dragBoxXAfter = dragabblePage.DragBoxX.Location.X;
            double dragBoxYAfter = dragabblePage.DragBoxY.Location.Y;

            dragabblePage.AssertCoordinates(629, dragBoxXBefore, 3);
            dragabblePage.AssertCoordinates(318, dragBoxYBefore, 3);
            dragabblePage.AssertCoordinates(782, dragBoxXAfter, 3);
            dragabblePage.AssertCoordinates(609, dragBoxYAfter, 3);
        }

        [Test]
        public void ElementCantDragOutsideTheBox_When_TryToDragOutside()
        {
            Driver.ScrollToElement(dragabblePage.ContainerTab).WaitAndClick();

            double textBoxXBefore = dragabblePage.TextBox.Location.X;
            double textBoxYBefore = dragabblePage.TextBox.Location.Y;

            Builder.DragAndDropToOffset(dragabblePage.TextBox.WrappedElement, 562, 106).Perform();

            double textBoxXAfter = dragabblePage.TextBox.Location.X;
            double textBoxYAfter = dragabblePage.TextBox.Location.Y;

            dragabblePage.AssertCoordinates(475, textBoxXBefore, 3);
            dragabblePage.AssertCoordinates(314, textBoxYBefore, 3);
            dragabblePage.AssertCoordinates(1037, textBoxXAfter, 3);
            dragabblePage.AssertCoordinates(420, textBoxYAfter, 3);
        }
    }
}