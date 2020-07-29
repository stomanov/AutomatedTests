using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumTasks.Factories.DemoQA;
using SeleniumTasks.Models.DemoQA;
using SeleniumTasks.Pages.DemoQA;
using SeleniumTasks.Pages.DemoQA.PracticeForm;

namespace SeleniumTasks.Tests.DemoQA.PracticeForm
{
    class PracticeFormTests : BaseTest
    {
        private HomePage _homePage;
        private DemoQAPage _demoQAPage;
        private PracticeFormPage _practiceFormPage;
        private PracticeFormModel _userRegistration;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _demoQAPage = new DemoQAPage(Driver);
            _practiceFormPage = new PracticeFormPage(Driver);
            
            Driver.NavigateTo(_homePage.URL);
            _homePage.CategoryCard("Forms").Click();
            _demoQAPage.LeftPanelSubMenu("Practice Form").Click();
            _userRegistration = PracticeFormFactory.CreateValidUser();
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
        public void ThanksMessageDisplayed_When_FillFormWithValidData()
        {
            _practiceFormPage.FillRegistrationForm(_userRegistration);
            _practiceFormPage.ClickSubmit();

            _practiceFormPage.AssertSuccessful_When_FillFormWithValidData(_practiceFormPage.Popup.ThanksMessage.Text);
        }

        [Test]
        public void GreenColorDisplayed_When_FillFormWithValidData()
        {
            _userRegistration.LastName = string.Empty;

            _practiceFormPage.FillRegistrationForm(_userRegistration);
            _practiceFormPage.ClickSubmit();
            _practiceFormPage.FirstName.Click();

            _practiceFormPage.AssertSuccessBorderColor(_practiceFormPage.FirstName);
        }

        [Test]
        public void ErrorMessageDisplayed_When_FillFormWithoutFirstName()
        {
            _userRegistration.FirstName = string.Empty;

            _practiceFormPage.FillRegistrationForm(_userRegistration);
            _practiceFormPage.ClickSubmit();
            _practiceFormPage.FirstName.Click();

            _practiceFormPage.AssertErrorBorderColor(_practiceFormPage.FirstName);
        }
    }
}
