using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;
using SeleniumProject.Pages.DemoQA.SelectablePage;
using System.Linq;

namespace SeleniumProject.Tests.DemoQA.Interactions
{
    class Selectable : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private SelectablePage selectablePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            selectablePage = new SelectablePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Interactions").WaitAndClick();
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Selectable")).WaitAndClick();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void NumbersColorChanged_When_SelectThem()
        {
            Driver.ScrollToElement(selectablePage.GridTab).WaitAndClick();

            for (int number = 0; number < 9; number += 2)
            {
                var colorBefore = selectablePage.GridOfNumbers[number].WrappedElement.GetCssColor();

                selectablePage.GridOfNumbers[number].WaitAndClick();

                var colorAfter = selectablePage.GridOfNumbers[number].WrappedElement.GetCssColor();

                selectablePage.AssertColorsBeforeAndAfter(colorBefore, colorAfter);
            }
        }

        [Test]
        public void SentencesColorIsChanged_When_Selected()
        {
            Driver.ScrollToElement(selectablePage.ListTab).WaitAndClick();

            for (int sentence = 0; sentence < 4; sentence += 2)
            {
                var colorBefore = selectablePage.ListOfSentences[sentence].WrappedElement.GetCssColor();

                selectablePage.ListOfSentences[sentence].WaitAndClick();

                var colorAfter = selectablePage.ListOfSentences[sentence].WrappedElement.GetCssColor();

                selectablePage.AssertColorsBeforeAndAfter(colorBefore, colorAfter);
            }
        }

        [Test]
        public void AllItemsColorChanged_When_SelectThem()
        {
            Driver.ScrollToElement(selectablePage.ListTab).WaitAndClick();

            foreach (var sentence in selectablePage.ListOfSentences)
            {
                sentence.WaitAndClick();
            }

            Assert.IsTrue(selectablePage.ListOfSentences.All(o => o.WrappedElement.GetCssColor() == "rgba(0, 123, 255, 1)"));
        }

        [Test]
        public void SelectedItemColorChange_When_SelectThemOneByOne([Range(0, 3)] int sentence)
        {
            Driver.ScrollToElement(selectablePage.ListTab).WaitAndClick();

            selectablePage.ListOfSentences[sentence].WaitAndClick();

            Assert.AreEqual(selectablePage.ListOfSentences[sentence].WrappedElement.GetCssColor(), "rgba(0, 123, 255, 1)");
        }
    }
}