using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;
using System.Linq;

namespace SeleniumTasks.Tests.DemoQA.Widgets
{
    public class AutoCompleteTests : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private AutoCompletePage _autoCompletePage;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();
            
            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _autoCompletePage = new AutoCompletePage(Driver);
            
            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Widgets").Click();
            _demoQAPage.LeftPanelSubMenu("Auto Complete").Click();
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
        public void Test1_TextDropDown_When_TypingInSingleColorField()
        {
            _autoCompletePage.SingleColorNameField.SendKeys("Re");

            _autoCompletePage.AssertColorsNamesAreDisplayed();
            _autoCompletePage.AssertColorsNamesAreTheSameAsDisplayed();
        }

        [Test]
        public void Test2_TextDropDown_When_TypingInTwoFields()
        {
            _autoCompletePage.TypingOnceInMultiColorNameField("Red");
            _autoCompletePage.TypingOnceInSingleColorNameField("Re");

            _autoCompletePage.AssertColorsNamesAreDisplayed();
            _autoCompletePage.AssertColorsNamesAreTheSameAsDisplayed();
        }

        [Test]
        public void Test3_TextDropDown_When_TypingInMultiColorField()
        {
            _autoCompletePage.TypingTwiceInMultiColorNameField("Red", "Re");

            var listOfColors = _autoCompletePage.ListOfColorsInMultiColor.Select(e => e.Text).ToList();

            Assert.IsTrue(_autoCompletePage.GreenColorAutoCompleteInMultiColor.Displayed);
            Assert.AreEqual("Green", _autoCompletePage.GreenColorAutoCompleteInMultiColor.Text);
            Assert.AreEqual(listOfColors.Count, 1);
            Assert.IsTrue(listOfColors.Contains("Green"));
        }
    }
}