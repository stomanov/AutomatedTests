using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;

namespace SeleniumTasks.Tests.DemoQA.Widgets
{
    public class DatePickerTests : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private DatePickerPage _datePickerPage;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();
            
            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _datePickerPage = new DatePickerPage(Driver);
            
            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Widgets").Click();
            _demoQAPage.LeftPanelSubMenu("Date Picker").Click();
            _datePickerPage.TypeRandomDate();
            _datePickerPage.SelectRandomDay(_datePickerPage.CreateRandomDayOfTheMonth());
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
        public void Test1_SelectedDayColorsAssert()
        {
            var selectedDayBackgroundColor = _datePickerPage.SelectedDay.GetCssValue("background-color");
            var selectedDayColor = _datePickerPage.SelectedDay.GetCssValue("color");

            Assert.AreEqual(selectedDayBackgroundColor, "rgba(33, 107, 165, 1)");
            Assert.AreEqual(selectedDayColor, "rgba(255, 255, 255, 1)");
        }

        [Test]
        public void Test2_HoverOverSelectedDayColorsAssert()
        {
            _datePickerPage.HoverOverSelectedDay();

            var selectedDayBackgroundColor = _datePickerPage.SelectedDay.GetCssValue("background-color");
            var selectedDayColor = _datePickerPage.SelectedDay.GetCssValue("color");

            Assert.AreEqual(selectedDayBackgroundColor, "rgba(29, 93, 144, 1)");
            Assert.AreEqual(selectedDayColor, "rgba(255, 255, 255, 1)");
        }

        [Test]
        public void Test3_HoverOverNotSelectedDayColorsAssert()
        {
            var randomDayOfTheMonth = _datePickerPage.CreateRandomDayOfTheMonth();
            _datePickerPage.HoverOverNotSelectedDay(randomDayOfTheMonth);

            var selectedDayBackgroundColor = _datePickerPage.NotSelectedDays[randomDayOfTheMonth].GetCssValue("background-color");
            var selectedDayColor = _datePickerPage.NotSelectedDays[randomDayOfTheMonth].GetCssValue("color");

            Assert.AreEqual(selectedDayBackgroundColor, "rgba(240, 240, 240, 1)");
            Assert.AreEqual(selectedDayColor, "rgba(0, 0, 0, 1)");
        }
    }
}