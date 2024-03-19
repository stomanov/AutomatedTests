using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.DemoQA;

namespace SeleniumProject.Tests.DemoQA.Navigation
{
    public class NavigationTests : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);

            Driver.NavigateTo(homePage.URL);
        }

        [TearDown]
        public void TearDown()
        {

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
            homePage.CategoryCard("Elements").WaitAndClick();

            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu(sectionName)).WaitAndClick();

            demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Practice Form")]

        public void LoadedSuccessfullyFormsPage_When_NavigateTo(string sectionName)
        {
            homePage.CategoryCard("Forms").WaitAndClick();

            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu(sectionName)).WaitAndClick();

            demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Browser Windows")]
        [TestCase("Alerts")]
        [TestCase("Frames")]
        [TestCase("Nested Frames")]
        [TestCase("Modal Dialogs")]
        public void LoadedSuccessfullyEachAlertsFrameAndWindowsPage_When_NavigateTo(string sectionName)
        {
            homePage.CategoryCard("Alerts, Frame & Windows").WaitAndClick();

            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu(sectionName)).WaitAndClick();

            demoQAPage.AssertPageTitle(sectionName);
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
            homePage.CategoryCard("Widgets").WaitAndClick();

            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu(sectionName)).WaitAndClick();

            demoQAPage.AssertPageTitle(sectionName);
        }

        [Test]
        [TestCase("Sortable")]
        [TestCase("Selectable")]
        [TestCase("Resizable")]
        [TestCase("Droppable")]
        [TestCase("Dragabble")]
        public void LoadedSuccessfullyEachInteractionsPage_When_NavigateTo(string sectionName)
        {
            homePage.CategoryCard("Interactions").WaitAndClick();

            Driver.ScrollToElement(demoQAPage.LeftPanelSubMenu(sectionName)).WaitAndClick();

            demoQAPage.AssertPageTitle(sectionName);
        }
    }
}