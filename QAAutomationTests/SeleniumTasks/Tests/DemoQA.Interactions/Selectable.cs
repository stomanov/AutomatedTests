using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;
using SeleniumTasks.Pages.DemoQA.SelectablePage;
using System.Linq;

namespace SeleniumTasks.Tests.DemoQA.Interactions
{
    class Selectable : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private SelectablePage _selectablePage;

        [SetUp]
        public void SetUp()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _selectablePage = new SelectablePage(Driver);

            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Interactions").Click();
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Selectable")).Click();
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
        public void NumbersColorChanged_When_SelectThem()
        {
            Driver.ScrollToElement(_selectablePage.GridTab).Click();

            for (int number = 0; number < 9; number += 2)
            {
                var colorBefore = _selectablePage.GridOfNumbers[number].WrappedElement.GetCssColor();

                _selectablePage.GridOfNumbers[number].Click();

                var colorAfter = _selectablePage.GridOfNumbers[number].WrappedElement.GetCssColor();

                _selectablePage.AssertColorsBeforeAndAfter(colorBefore, colorAfter);
            }
        }

        [Test]
        public void SentencesColorIsChanged_When_Selected()
        {
            Driver.ScrollToElement(_selectablePage.ListTab).Click();

            for (int sentence = 0; sentence < 4; sentence += 2)
            {
                var colorBefore = _selectablePage.ListOfSentences[sentence].WrappedElement.GetCssColor();

                _selectablePage.ListOfSentences[sentence].Click();

                var colorAfter = _selectablePage.ListOfSentences[sentence].WrappedElement.GetCssColor();

                _selectablePage.AssertColorsBeforeAndAfter(colorBefore, colorAfter);

            }
        }

        [Test]
        public void AllItemsColorChanged_When_SelectThem()
        {
            Driver.ScrollToElement(_selectablePage.ListTab).Click();

            foreach (var sentence in _selectablePage.ListOfSentences)
            {
                sentence.Click();
            }

            Assert.IsTrue(_selectablePage.ListOfSentences.All(o => o.WrappedElement.GetCssColor() == "rgba(0, 123, 255, 1)"));
        }

        [Test]
        public void SelectedItemColorChange_When_SelectThemOneByOne([Range(0, 3)] int sentence)
        {
            Driver.ScrollToElement(_selectablePage.ListTab).Click();

            _selectablePage.ListOfSentences[sentence].Click();

            Assert.AreEqual(_selectablePage.ListOfSentences[sentence].WrappedElement.GetCssColor(), "rgba(0, 123, 255, 1)");
        }

    }
}
