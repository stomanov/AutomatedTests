using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;
using SeleniumTasks.Pages.DemoQA.SortablePage;

namespace SeleniumTasks.Tests.DemoQA.Interactions
{
    class Sortable : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private SortablePage _sortablePage;
        private int _index;

        [SetUp]
        public void SetUp()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _sortablePage = new SortablePage(Driver);

            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Interactions").Click();
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Sortable")).Click();
            _index = 1;
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
        public void NumberTwoChanged_When_MovedInList()
        {
            Driver.ScrollToElement(_sortablePage.ListTab).Click();

            Builder.DragAndDropToOffset(_sortablePage.ListOfNumbers[_index].WrappedElement, 0, 150).Perform();

            _sortablePage.AssertTextByIndexList("Two", _index + 3);
        }

        [Test]
        public void NumberTwoChanged_When_MovedInGrid()
        {
            Driver.ScrollToElement(_sortablePage.GridTab).Click();

            Builder.DragAndDropToOffset(_sortablePage.GridOfNumbers[_index].WrappedElement, 20, 120).Perform();

            _sortablePage.AssertTextByIndexGrid("Four", _index + 1);
        }
    }
}