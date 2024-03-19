using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Entities.DemoQA;
using SeleniumProject.Pages.DemoQA;
using SeleniumProject.Pages.DemoQA.PracticeForm;

namespace SeleniumProject.Tests.DemoQA.PracticeForm
{
    class PracticeFormTests : BaseTest
    {
        private HomePage homePage;
        private DemoQAPage demoQAPage;
        private PracticeFormPage practiceFormPage;
        private PracticeFormModel userRegistration;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            demoQAPage = new DemoQAPage(Driver);
            practiceFormPage = new PracticeFormPage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.CategoryCard("Forms").WaitAndClick();
            demoQAPage.LeftPanelSubMenu("Practice Form").WaitAndClick();
            userRegistration = PracticeFormFactory.CreateValidUser();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ThanksMessageDisplayed_When_FillFormWithValidData()
        {
            practiceFormPage.FillRegistrationForm(userRegistration);
            practiceFormPage.ClickSubmit();

            practiceFormPage.AssertSuccessful_When_FillFormWithValidData(practiceFormPage.Popup.ThanksMessage.Text);
        }

        [Test]
        public void GreenColorDisplayed_When_FillFormWithValidData()
        {
            userRegistration.LastName = string.Empty;

            practiceFormPage.FillRegistrationForm(userRegistration);
            practiceFormPage.ClickSubmit();
            practiceFormPage.FirstName.WaitAndClick();

            practiceFormPage.AssertSuccessBorderColor(practiceFormPage.FirstName);
        }

        [Test]
        public void ErrorMessageDisplayed_When_FillFormWithoutFirstName()
        {
            userRegistration.FirstName = string.Empty;

            practiceFormPage.FillRegistrationForm(userRegistration);
            practiceFormPage.ClickSubmit();
            practiceFormPage.FirstName.WaitAndClick();

            practiceFormPage.AssertErrorBorderColor(practiceFormPage.FirstName);
        }
    }
}
