using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.DemoQA
{
    public class DatePickerPage : DemoQAPage
    {
        public DatePickerPage(WebDriver driver) : base(driver) { }

        public WebElement SelectDateInput => Driver.FindElement(By.XPath("//*[@id='datePickerMonthYearInput']"));

        public WebElement SelectMonthDropDownMenu => Driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));

        public WebElement CalendarTitle => Driver.FindElement(By.XPath("//div[contains(@class, 'current-month')]"));

        public List<WebElement> DayOption => Driver.FindElements(By.XPath("//div[@class='react-datepicker__month']//div[contains(@class, 'react-datepicker__day') and not(contains(@class, 'outside-month'))]")).ToList();

        public WebElement SelectedDay => Driver.FindElement(By.XPath("//*[@id='datePickerMonthYear']//div[contains(@class, 'selected')]"));

        public List<WebElement> NotSelectedDays => Driver.FindElements(By.XPath("//*[@id='datePickerMonthYear']//div[contains(@class, 'react-datepicker__day') and not(contains(@class, 'selected'))and not(contains(@class, 'name'))]")).ToList();

        public void SelectCurrentMonth(string currentMonth)
        {
            SelectDateInput.FillText(Keys.Control + "a" + Keys.Backspace);
            SelectMonthDropDownMenu.WaitAndClick();
            WebElement monthOption = SelectMonthDropDownMenu.FindElement(By.XPath($".//*[normalize-space(text())='{currentMonth}']"));
            monthOption.WaitAndClick();
        }

        public int CreateRandomDayOfTheMonth()
        {
            var daysInMonth = new Random();
            int randomDayOfTheMonth = daysInMonth.Next(DayOption.Count);
            return randomDayOfTheMonth;
        }

        public void SelectRandomDay(int randomDayOfTheMonth)
        {
            DayOption[randomDayOfTheMonth].WaitAndClick();
            SelectDateInput.WaitAndClick();
        }

        public void TypeRandomDate()
        {
            var random = new Random();
            var randomDate = $"{random.Next(12)}" + "/" + $"{random.Next(28)}" + "/" + "2020";
            SelectDateInput.FillText(Keys.Control + "a" + Keys.Backspace);
            SelectDateInput.FillText(randomDate.ToString());
        }

        public void HoverOverSelectedDay()
        {
            Builder.MoveToElement(SelectedDay.WrappedElement).Perform();
        }

        public void HoverOverNotSelectedDay(int randomDayOfTheMonth)
        {
            Builder.MoveToElement(NotSelectedDays[randomDayOfTheMonth].WrappedElement).Perform();
        }
    }
}