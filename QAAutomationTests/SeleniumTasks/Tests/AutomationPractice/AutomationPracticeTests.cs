using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.AutomationPractice;
using SeleniumProject.Entities.AutomationPractice;
using System.Linq;

namespace SeleniumProject.Tests.AutomationPractice
{
    public class AutomationPracticeTests : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private AuthenticationPage authenticationPage;
        private UserModel userRegistration;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);
            authenticationPage = new AuthenticationPage(Driver);
            
            Driver.NavigateTo(homePage.URL);
            homePage.SignInHeader.WaitAndClick();
            homePage.SignUp();
            userRegistration = UserFactory.CreateValidUser();
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void Test1_ErrorMessagesShowed_When_FillRegistrationFormWithoutFirstAndLastName()
        {
            userRegistration.FirstName = string.Empty;
            userRegistration.LastName = string.Empty;
            
            loginPage.FillRegistrationForm(userRegistration);
            loginPage.RegisterButton.WaitAndClick();

            Assert.IsTrue(authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("lastname is required.", authenticationPage.ErrorMessages[0].Text);
            Assert.AreEqual("firstname is required.", authenticationPage.ErrorMessages[1].Text);
        }

        [Test]
        public void Test2_ErrorMessageShowed_When_FillRegistrationFormWithoutPassword()
        {
            userRegistration.Password = string.Empty;
            
            loginPage.FillRegistrationForm(userRegistration);
            loginPage.RegisterButton.WaitAndClick();

            Assert.IsTrue(authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("passwd is required.", authenticationPage.ErrorMessages[0].Text);
            
        }

        [Test]
        public void Test3_ErrorMessageShowed_When_FillRegistrationFormWithoutCity()
        {
            userRegistration.City = string.Empty;

            loginPage.FillRegistrationForm(userRegistration);
            loginPage.RegisterButton.WaitAndClick();

            Assert.IsTrue(authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("city is required.", authenticationPage.ErrorMessages[0].Text);
        }

        [Test]
        public void Test4_ErrorMessageShowed_When_FillRegistrationFormWithoutPhone()
        {
            userRegistration.Phone = string.Empty;

            loginPage.FillRegistrationForm(userRegistration);
            loginPage.RegisterButton.WaitAndClick();

            Assert.IsTrue(authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("You must register at least one phone number.", authenticationPage.ErrorMessages[0].Text);
        }

        [Test]
        public void Test5_ErrorMessageShowed_When_FillRegistrationFormWithoutState()
        {
            userRegistration.State = "-";

            loginPage.FillRegistrationForm(userRegistration);
            loginPage.RegisterButton.WaitAndClick();

            Assert.IsTrue(authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("This country requires you to choose a State.", authenticationPage.ErrorMessages[0].Text);
        }

        [Test]
        public void Test6_AllErrorMessagesShowed_When_FillRegistrationFormEmpty()
        {
            loginPage.ScrollTo(loginPage.RegisterButton);
            loginPage.RegisterButton.WaitAndClick();

            var allErrorsExpected = authenticationPage.allErrorsList.ToList();
            var allErrors = authenticationPage.ErrorMessages.Select(e => e.Text).ToList();
            
            Assert.IsTrue(authenticationPage.AlertMessage.Text.Contains("error"));
            CollectionAssert.AreEqual(allErrorsExpected, allErrors);
        }
    }
}