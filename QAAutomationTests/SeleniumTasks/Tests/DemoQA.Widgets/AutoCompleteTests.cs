using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;
using System.Linq;

namespace SeleniumProject.Tests.DemoQA.Widgets
{
    public class AutoCompleteTests : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private AutoCompletePage autoCompletePage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            autoCompletePage = new AutoCompletePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Widgets").WaitAndClick();
            demoQAPage.LeftPanelSubMenu("Auto Complete").WaitAndClick();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test1_TextDropDown_When_TypingInSingleColorField()
        {
            autoCompletePage.SingleColorNameField.FillText("Re");

            autoCompletePage.AssertColorsNamesAreDisplayed();
            autoCompletePage.AssertColorsNamesAreTheSameAsDisplayed();
        }

        [Test]
        public void Test2_TextDropDown_When_TypingInTwoFields()
        {
            autoCompletePage.TypingOnceInMultiColorNameField("Red");
            autoCompletePage.TypingOnceInSingleColorNameField("Re");

            autoCompletePage.AssertColorsNamesAreDisplayed();
            autoCompletePage.AssertColorsNamesAreTheSameAsDisplayed();
        }

        [Test]
        public void Test3_TextDropDown_When_TypingInMultiColorField()
        {
            autoCompletePage.TypingTwiceInMultiColorNameField("Red", "Re");

            var listOfColors = autoCompletePage.ListOfColorsInMultiColor.Select(e => e.Text).ToList();

            Assert.IsTrue(autoCompletePage.GreenColorAutoCompleteInMultiColor.Displayed);
            Assert.AreEqual("Green", autoCompletePage.GreenColorAutoCompleteInMultiColor.Text);
            Assert.AreEqual(listOfColors.Count, 1);
            Assert.IsTrue(listOfColors.Contains("Green"));
        }
    }
}