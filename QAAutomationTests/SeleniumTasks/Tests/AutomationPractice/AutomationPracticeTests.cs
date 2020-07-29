using NUnit.Framework;
using SeleniumTasks.Factories.AutomationPractice;
using SeleniumTasks.Models.AutomationPractice;
using SeleniumTasks.Pages.AutomationPractice;
using System.Linq;

namespace SeleniumTasks.Tests.AutomationPractice
{
    public class AutomationPracticeTests : BaseTest
    {
        private HomePage _homePage;
        private LoginPage _loginPage;
        private AuthenticationPage _authenticationPage;
        private UserModel _userRegistration;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _loginPage = new LoginPage(Driver);
            _authenticationPage = new AuthenticationPage(Driver);
            
            Driver.NavigateTo(_homePage.URL);
            _homePage.SignInHeader.Click();
            _homePage.SignUp();
            _userRegistration = UserFactory.CreateValidUser();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void Test1_ErrorMessagesShowed_When_FillRegistrationFormWithoutFirstAndLastName()
        {
            _userRegistration.FirstName = string.Empty;
            _userRegistration.LastName = string.Empty;
            
            _loginPage.FillRegistrationForm(_userRegistration);
            _loginPage.RegisterButton.Click();

            Assert.IsTrue(_authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("lastname is required.", _authenticationPage.ErrorMessages[0].Text);
            Assert.AreEqual("firstname is required.", _authenticationPage.ErrorMessages[1].Text);
        }

        [Test]
        public void Test2_ErrorMessageShowed_When_FillRegistrationFormWithoutPassword()
        {
            _userRegistration.Password = string.Empty;
            
            _loginPage.FillRegistrationForm(_userRegistration);
            _loginPage.RegisterButton.Click();

            Assert.IsTrue(_authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("passwd is required.", _authenticationPage.ErrorMessages[0].Text);
            
        }

        [Test]
        public void Test3_ErrorMessageShowed_When_FillRegistrationFormWithoutCity()
        {
            _userRegistration.City = string.Empty;

            _loginPage.FillRegistrationForm(_userRegistration);
            _loginPage.RegisterButton.Click();

            Assert.IsTrue(_authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("city is required.", _authenticationPage.ErrorMessages[0].Text);
        }

        [Test]
        public void Test4_ErrorMessageShowed_When_FillRegistrationFormWithoutPhone()
        {
            _userRegistration.Phone = string.Empty;

            _loginPage.FillRegistrationForm(_userRegistration);
            _loginPage.RegisterButton.Click();

            Assert.IsTrue(_authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("You must register at least one phone number.", _authenticationPage.ErrorMessages[0].Text);
        }

        [Test]
        public void Test5_ErrorMessageShowed_When_FillRegistrationFormWithoutState()
        {
            _userRegistration.State = "-";

            _loginPage.FillRegistrationForm(_userRegistration);
            _loginPage.RegisterButton.Click();

            Assert.IsTrue(_authenticationPage.AlertMessage.Text.Contains("error"));
            Assert.AreEqual("This country requires you to choose a State.", _authenticationPage.ErrorMessages[0].Text);
        }

        [Test]
        public void Test6_AllErrorMessagesShowed_When_FillRegistrationFormEmpty()
        {
            _loginPage.ScrollTo(_loginPage.RegisterButton);
            _loginPage.RegisterButton.Click();

            var allErrorsExpected = _authenticationPage.allErrorsList.ToList();
            var allErrors = _authenticationPage.ErrorMessages.Select(e => e.Text).ToList();
            
            Assert.IsTrue(_authenticationPage.AlertMessage.Text.Contains("error"));
            CollectionAssert.AreEqual(allErrorsExpected, allErrors);
        }
    }
}