using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;
using SeleniumProject.Entities.AutomationPractice;

namespace SeleniumProject.Pages.AutomationPractice
{
    public class LoginPage : HomePage
    {
        public LoginPage(WebDriver driver) : base(driver) { }

        public void FillRegistrationForm(UserModel user)
        {
            Gender[(int)AutomationPractice.Gender.Female].WaitAndClick();

            FirstName.FillText(user.FirstName);
            LastName.FillText(user.LastName);
            Password.FillText(user.Password);

            var date = new SelectElement(DayDateDropDown.WrappedElement);
            date.SelectByValue(user.Day);

            var month = new SelectElement(MonthDateDropDown.WrappedElement);
            month.SelectByValue(user.Month);

            var year = new SelectElement(YearDateDropDown.WrappedElement);
            year.SelectByValue(user.Year);

            Address.FillText(user.Address);
            City.FillText(user.City);
            Postcode.FillText(user.PostCode);
            PhoneMobile.FillText(user.Phone);

            var state = new SelectElement(StateDropDown.WrappedElement);
            state.SelectByText(user.State);
        }

        //public List<WebElement> Gender => Driver.FindElements(By.XPath("//[@name='id_gender']")).ToList();
        public List<WebElement> Gender => Driver.FindElements(By.XPath("//label[contains(@for, 'id_gender')]")).ToList();

        public WebElement FirstName => Driver.FindExistingElement(By.XPath("//*[@id='customer_firstname']"));

        public WebElement LastName => Driver.FindExistingElement(By.XPath("//*[@id='customer_lastname']"));

        public WebElement Password => Driver.FindExistingElement(By.XPath("//*[@id='passwd']"));

        public WebElement DayDateDropDown => Driver.FindExistingElement(By.XPath("//*[@id='days']"));

        public WebElement MonthDateDropDown => Driver.FindExistingElement(By.XPath("//*[@id='months']"));

        public WebElement YearDateDropDown => Driver.FindExistingElement(By.XPath("//*[@id='years']"));

        public WebElement Address => Driver.FindExistingElement(By.XPath("//*[@id='address1']"));

        public WebElement City => Driver.FindExistingElement(By.XPath("//*[@id='city']"));

        public WebElement Postcode => Driver.FindExistingElement(By.XPath("//*[@id='postcode']"));

        public WebElement PhoneMobile => Driver.FindExistingElement(By.XPath("//*[@id='phone_mobile']"));

        public WebElement StateDropDown => Driver.FindExistingElement(By.XPath("//*[@id='id_state']"));

        public WebElement RegisterButton => Driver.FindClickableElement(By.XPath("//*[@id='submitAccount']"));
    }
}