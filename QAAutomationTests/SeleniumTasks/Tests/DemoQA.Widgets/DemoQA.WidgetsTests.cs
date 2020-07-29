using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages;
using SeleniumTasks.Pages.DemoQA;

namespace SeleniumTasks.Tests.DemoQA.Widgets
{
    public class DemoQAWidgetsTests : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private DatePickerPage _datePickerPage;
        private SliderPage _sliderPage;
        private ProgressBarPage _progressBarPage;
        private TooltipsPage _toolTipsPage;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _datePickerPage = new DatePickerPage(Driver);
            _sliderPage = new SliderPage(Driver);
            _progressBarPage = new ProgressBarPage(Driver);
            _toolTipsPage = new TooltipsPage(Driver);
            
            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Widgets").Click();
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
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Date Picker")).Click();
            
            _datePickerPage.SelectCurrentMonth(currentMonthOfTheYear);
            var randomDayOfTheMonth = _datePickerPage.CreateRandomDayOfTheMonth();
            _datePickerPage.SelectRandomDay(randomDayOfTheMonth);

            Assert.AreEqual($"{currentMonthOfTheYear} 2020", _datePickerPage.CalendarTitle.Text);
            Assert.IsTrue(_datePickerPage.DayOption[randomDayOfTheMonth].GetAttribute("class").Contains("selected"));
        }

        [Test]
        public void Test2_SliderIsSetTo100_When_Slided()
        {
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Slider")).Click();
           
            _sliderPage.Slide();

            Assert.AreEqual("86", _sliderPage.SliderToolTip.Text, _sliderPage.SliderValue.GetAttribute("value"));
        }

        [Test]
        public void Test3_ProgressBarIsStopedOn20_When_Triggered()
        {
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Progress Bar")).Click();
            
            _progressBarPage.StartAndThenStopProgressBar();

            Assert.AreEqual("20%", _progressBarPage.ProgressBarValue.Text);
        }

        [Test]
        public void Test4_TooltipPopupIsShowed_When_HoverOverTheTextField()
        {
            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu("Tool Tips")).Click();
            
            _toolTipsPage.HoverToolTip();

            Assert.IsTrue(_toolTipsPage.ToolTipPopup.Displayed);
            Assert.AreEqual("You hovered over the text field", _toolTipsPage.ToolTipPopup.Text);
        }
    }
}