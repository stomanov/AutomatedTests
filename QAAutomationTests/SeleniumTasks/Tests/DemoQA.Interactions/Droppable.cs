using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;
using SeleniumProject.Pages.DemoQA.DroppablePage;

namespace SeleniumProject.Tests.DemoQA.Interactions
{
    class Droppable : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private DroppablePage droppablePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            droppablePage = new DroppablePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Interactions").WaitAndClick();
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Droppable")).WaitAndClick();
            Driver.ScrollToElement(droppablePage.SimpleTab).WaitAndClick();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TargetBoxColorIsChanged_When_ElementIsDraggedAndDroppedInsideAndThenOutside()
        {
            var colorBefore = droppablePage.TargetBox.WrappedElement.GetCssColor();

            Builder
                .DragAndDrop(droppablePage.SourceBox.WrappedElement, droppablePage.TargetBox.WrappedElement)
                .DragAndDropToOffset(droppablePage.SourceBox.WrappedElement, 0, 180)
                .Perform();

            var colorAfter = droppablePage.TargetBox.WrappedElement.GetCssColor();

            droppablePage.AssertColorsBeforeAndAfter(colorAfter, colorBefore);
        }

        [Test]
        public void TargetBoxColorIsChanged_When_ElementIsDraggedAndDroppedInside()
        {
            var colorBefore = droppablePage.TargetBox.WrappedElement.GetCssColor();

            Builder.DragAndDrop(droppablePage.SourceBox.WrappedElement, droppablePage.TargetBox.WrappedElement).Perform();

            var colorAfter = droppablePage.TargetBox.WrappedElement.GetCssColor();

            droppablePage.AssertColorsBeforeAndAfter(colorAfter, colorBefore);
        }

        [Test]
        public void SourceBoxCoordinatesChanged_When_DragAndDropped()
        {
            double sourcePosXBefore = droppablePage.SourceBox.Location.X;
            double sourcePosYBefore = droppablePage.SourceBox.Location.Y;

            Builder.DragAndDropToOffset(droppablePage.SourceBox.WrappedElement, 200, 150).Perform();

            double sourcePosXAfter = droppablePage.SourceBox.Location.X;
            double sourcePosYAfter = droppablePage.SourceBox.Location.Y;

            droppablePage.AssertCoordinates(612, sourcePosXBefore, 3);
            droppablePage.AssertCoordinates(302, sourcePosYBefore, 3);
            droppablePage.AssertCoordinates(812, sourcePosXAfter, 3);
            droppablePage.AssertCoordinates(452, sourcePosYAfter, 3);
        }
    }
}