using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;
using SeleniumProject.BaseProject;
using SeleniumProject.Entities.DemoQA;

namespace SeleniumProject.Pages.DemoQA.PracticeForm
{
    public class PracticeFormPage : BasePage
    {
        public PracticeFormPage(WebDriver driver) : base(driver) { }

        public void FillRegistrationForm(PracticeFormModel user)
        {
            FirstName.ClearAndFillText(user.FirstName);
            LastName.ClearAndFillText(user.LastName);
            Email.ClearAndFillText(user.Email);
            Gender(user.Gender).WaitAndClick();
            PhoneNumber.ClearAndFillText(user.PhoneNumber);
            SelectDate();
            SelectSubjects();
            Hobbies(user.Hobby1).WaitAndClick();
            Hobbies(user.Hobby2).WaitAndClick();
            Address.ClearAndFillText(user.Address);
            SelectState(user.State);
            SelectCity(user.City);
        }

        public void SelectDate()
        {
            DateOfBirthMenu.WaitAndClick();

            var month = new SelectElement(MonthDateDropDown.WrappedElement);
            month.SelectByValue(PracticeFormFactory.CreateValidUser().Month);

            var year = new SelectElement(YearDateDropDown.WrappedElement);
            year.SelectByValue(PracticeFormFactory.CreateValidUser().Year);

            var daysInMonth = new Random();
            var randomDayOfTheMonth = daysInMonth.Next(DaysInMonth.Count);
            DaysInMonth[randomDayOfTheMonth].WaitAndClick();
        }

        public void SelectSubjects()
        {
            Builder.Click(Subjects.WrappedElement).SendKeys("a" + Keys.Tab).SendKeys("b" + Keys.Tab).SendKeys("c" + Keys.Tab).Perform();
        }

        public void SelectState(string state)
        {
            State.WaitAndClick();
            StateDropDown(state).WaitAndClick();
        }

        public void SelectCity(string city)
        {
            City.WaitAndClick();
            CityDropDown(city).WaitAndClick();
        }

        public void ClickSubmit()
        {
            Driver.ScrollToElement(SubmitButton).WaitAndClick();
        }

        public PracticeFormSection Popup => new PracticeFormSection(Driver);

        public WebElement FirstName => Driver.FindElement(By.XPath("//*[@id='firstName']"));

        public WebElement LastName => Driver.FindElement(By.XPath("//*[@id='lastName']"));

        public WebElement Email => Driver.FindElement(By.XPath("//*[@id='userEmail']"));

        public WebElement Gender(string gender)
        {
            return Driver.FindExistingElement(By.XPath($"//*[@id='genterWrapper']//label[text()='{gender}']"));
        }

        public WebElement PhoneNumber => Driver.FindElement(By.XPath("//*[@id='userNumber']"));

        public WebElement DateOfBirthMenu => Driver.FindElement(By.XPath("//*[@id='dateOfBirthInput']"));

        public List<WebElement> DaysInMonth => Driver.FindElements(By.XPath("//div[@class='react-datepicker__month']//div[contains(@class, 'react-datepicker__day') and not(contains(@class, 'outside-month'))]")).ToList();

        public WebElement MonthDateDropDown => Driver.FindExistingElement(By.XPath("//select[@class='react-datepicker__month-select']"));

        public WebElement YearDateDropDown => Driver.FindExistingElement(By.XPath("//select[@class='react-datepicker__year-select']"));

        public WebElement Subjects => Driver.FindElement(By.XPath("//*[@id='subjectsInput']"));

        public WebElement Hobbies(string hobby)
        {
            return Driver.FindExistingElement(By.XPath($"//*[@id='hobbiesWrapper']//label[text()='{hobby}']"));
        }

        public WebElement Address => Driver.FindElement(By.XPath("//*[@id='currentAddress']"));

        public WebElement State => Driver.FindExistingElement(By.XPath("//*[@id='state']"));

        public WebElement StateDropDown(string state)
        {
            return Driver.FindExistingElement(By.XPath($"//div[contains(text(), '{state}')]"));
        }

        public WebElement City => Driver.FindExistingElement(By.XPath("//*[@id='city']"));

        public WebElement CityDropDown(string city)
        {
            return Driver.FindExistingElement(By.XPath($"//div[contains(text(), '{city}')]"));
        }

        public WebElement SubmitButton => Driver.FindElement(By.XPath("//*[@id='submit']"));
         
        public void AssertSuccessful_When_FillFormWithValidData(string element)
        {
            Assert.AreEqual("Thanks for submitting the form", element);
        }

        public void AssertErrorBorderColor(WebElement element)
        {
            Assert.AreEqual("rgb(220, 53, 69)", element.WrappedElement.GetCssValue("border-color"));
        }

        public void AssertSuccessBorderColor(WebElement element)
        {
            Assert.AreEqual("rgb(40, 167, 69)", element.WrappedElement.GetCssValue("border-color"));
        }
    }
}