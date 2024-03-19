using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages;
using SeleniumProject.Pages.DemoQA;

namespace SeleniumProject.Tests.DemoQA.Widgets
{
    public class DemoQAWidgetsTests : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private DatePickerPage datePickerPage;
        private SliderPage sliderPage;
        private ProgressBarPage progressBarPage;
        private TooltipsPage toolTipsPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            datePickerPage = new DatePickerPage(Driver);
            sliderPage = new SliderPage(Driver);
            progressBarPage = new ProgressBarPage(Driver);
            toolTipsPage = new TooltipsPage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Widgets").WaitAndClick();
        }

        [Test]
        [TestCase("January")]
        [TestCase("February")]
        [TestCase("March")]
        [TestCase("April")]
        [TestCase("May")]
        [TestCase("June")]
        [TestCase("July")]
        [TestCase("August")]
        [TestCase("September")]
        [TestCase("October")]
        [TestCase("November")]
        [TestCase("December")]
        public void Test1_CalendarTitleIsTheSameWithSelection_When_SelectedTheMonth(string currentMonthOfTheYear)
        {
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Date Picker")).WaitAndClick();

            datePickerPage.SelectCurrentMonth(currentMonthOfTheYear);
            var randomDayOfTheMonth = datePickerPage.CreateRandomDayOfTheMonth();
            datePickerPage.SelectRandomDay(randomDayOfTheMonth);

            Assert.AreEqual($"{currentMonthOfTheYear} 2020", datePickerPage.CalendarTitle.Text);
            Assert.IsTrue(datePickerPage.DayOption[randomDayOfTheMonth].GetAttribute("class").Contains("selected"));
        }

        [Test]
        public void Test2_SliderIsSetTo100_When_Slided()
        {
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Slider")).WaitAndClick();

            sliderPage.Slide();

            Assert.AreEqual("81", sliderPage.SliderToolTip.Text, sliderPage.SliderValue.GetAttribute("value"));
        }

        [Test]
        public void Test3_ProgressBarIsStopedOn20_When_Triggered()
        {
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Progress Bar")).WaitAndClick();

            progressBarPage.StartAndThenStopProgressBar();

            Assert.AreEqual("20%", progressBarPage.ProgressBarValue.Text);
        }

        [Test]
        public void Test4_TooltipPopupIsShowed_When_HoverOverTheTextField()
        {
            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu("Tool Tips")).WaitAndClick();

            toolTipsPage.HoverToolTip();

            Assert.IsTrue(toolTipsPage.ToolTipPopup.Displayed);
            Assert.AreEqual("You hovered over the text field", toolTipsPage.ToolTipPopup.Text);
        }
    }
}