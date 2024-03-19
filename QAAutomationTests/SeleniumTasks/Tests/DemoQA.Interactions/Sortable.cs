using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;
using SeleniumProject.Pages.DemoQA.SortablePage;

namespace SeleniumProject.Tests.DemoQA.Interactions
{
    class Sortable : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private SortablePage sortablePage;
        private int index;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            sortablePage = new SortablePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Interactions").WaitAndClick();
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Sortable")).WaitAndClick();
            index = 1;
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void NumberTwoChanged_When_MovedInList()
        {
            Driver.ScrollToElement(sortablePage.ListTab).WaitAndClick();

            Builder.DragAndDropToOffset(sortablePage.ListOfNumbers[index].WrappedElement, 0, 150).Perform();

            sortablePage.AssertTextByIndexList("Two", index + 3);
        }

        [Test]
        public void NumberTwoChanged_When_MovedInGrid()
        {
            Driver.ScrollToElement(sortablePage.GridTab).WaitAndClick();

            Builder.DragAndDropToOffset(sortablePage.GridOfNumbers[index].WrappedElement, 20, 120).Perform();

            sortablePage.AssertTextByIndexGrid("Four", index + 1);
        }
    }
}