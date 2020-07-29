using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Pages.DemoQA;

namespace SeleniumTasks.Tests.DemoQA.Navigation
{
    public class NavigationTests : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            
            Driver.NavigateTo(_homePage.URL);
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
        [TestCase("Text Box")]
        [TestCase("Check Box")]
        [TestCase("Radio Button")]
        [TestCase("Web Tables")]
        [TestCase("Buttons")]
        [TestCase("Links")]
        [TestCase("Upload and Download")]
        [TestCase("Dynamic Properties")]
        public void LoadedSuccessfullyEachElementsPage_When_NavigateTo(string sectionName)
        {
            _homePage.CategoryCard("Elements").Click();

            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu(sectionName)).Click();

            _demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Practice Form")]

        public void LoadedSuccessfullyFormsPage_When_NavigateTo(string sectionName)
        {
            _homePage.CategoryCard("Forms").Click();

            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu(sectionName)).Click();

            _demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Browser Windows")]
        [TestCase("Alerts")]
        [TestCase("Frames")]
        [TestCase("NestedFrames")]
        [TestCase("Modal Dialogs")]
        public void LoadedSuccessfullyEachAlertsFrameAndWindowsPage_When_NavigateTo(string sectionName)
        {
            _homePage.CategoryCard("Alerts, Frame & Windows").Click();

            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu(sectionName)).Click();

            _demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Accordian")]
        [TestCase("Auto Complete")]
        [TestCase("Date Picker")]
        [TestCase("Slider")]
        [TestCase("Progress Bar")]
        [TestCase("Tabs")]
        [TestCase("Tool Tips")]
        [TestCase("Menu")]
        [TestCase("Select Menu")]
        public void LoadedSuccessfullyEachWidgetsPage_When_NavigateTo(string sectionName)
        {
            _homePage.CategoryCard("Widgets").Click();

            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu(sectionName)).Click();

            _demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Sortable")]
        [TestCase("Selectable")]
        [TestCase("Resizable")]
        [TestCase("Droppable")]
        [TestCase("Dragabble")]
        public void LoadedSuccessfullyEachInteractionsPage_When_NavigateTo(string sectionName)
        {
            _homePage.CategoryCard("Interactions").Click();

            Driver.ScrollToElement(_demoQAPage.LeftPanelSubMenu(sectionName)).Click();

            _demoQAPage.AssertPageTitle(sectionName);
        }
    }   
}