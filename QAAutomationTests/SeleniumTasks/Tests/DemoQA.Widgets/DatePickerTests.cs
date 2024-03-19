using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;

namespace SeleniumProject.Tests.DemoQA.Widgets
{
    public class DatePickerTests : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private DatePickerPage datePickerPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            datePickerPage = new DatePickerPage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Widgets").WaitAndClick();
            demoQAPage.LeftPanelSubMenu("Date Picker").WaitAndClick();
            datePickerPage.TypeRandomDate();
            datePickerPage.SelectRandomDay(datePickerPage.CreateRandomDayOfTheMonth());
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test1_SelectedDayColorsAssert()
        {
            var selectedDayBackgroundColor = datePickerPage.SelectedDay.GetCssValue("background-color");
            var selectedDayColor = datePickerPage.SelectedDay.GetCssValue("color");

            Assert.AreEqual(selectedDayBackgroundColor, "rgba(33, 107, 165, 1)");
            Assert.AreEqual(selectedDayColor, "rgba(255, 255, 255, 1)");
        }

        [Test]
        public void Test2_HoverOverSelectedDayColorsAssert()
        {
            datePickerPage.HoverOverSelectedDay();

            var selectedDayBackgroundColor = datePickerPage.SelectedDay.GetCssValue("background-color");
            var selectedDayColor = datePickerPage.SelectedDay.GetCssValue("color");

            Assert.AreEqual(selectedDayBackgroundColor, "rgba(29, 93, 144, 1)");
            Assert.AreEqual(selectedDayColor, "rgba(255, 255, 255, 1)");
        }

        [Test]
        public void Test3_HoverOverNotSelectedDayColorsAssert()
        {
            var randomDayOfTheMonth = datePickerPage.CreateRandomDayOfTheMonth();
            datePickerPage.HoverOverNotSelectedDay(randomDayOfTheMonth);

            var selectedDayBackgroundColor = datePickerPage.NotSelectedDays[randomDayOfTheMonth].GetCssValue("background-color");
            var selectedDayColor = datePickerPage.NotSelectedDays[randomDayOfTheMonth].GetCssValue("color");

            Assert.AreEqual(selectedDayBackgroundColor, "rgba(240, 240, 240, 1)");
            Assert.AreEqual(selectedDayColor, "rgba(0, 0, 0, 1)");
        }
    }
}