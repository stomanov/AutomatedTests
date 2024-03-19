using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.AutomationPractice
{
    public class AuthenticationPage : HomePage
    {
        public AuthenticationPage(WebDriver driver) : base(driver) { }

        public WebElement AlertMessage => Driver.FindExistingElement(By.XPath("//*[@id='center_column']//div[(@class='alert alert-danger')]"));

        public List<WebElement> ErrorMessages => Driver.FindElements(By.XPath("//*[@id='center_column']//li")).ToList();

        public string[] allErrorsList = { "You must register at least one phone number.", "lastname is required.", "firstname is required.", "passwd is required.", "address1 is required.", "city is required.", "The Zip/Postal code you've entered is invalid. It must follow this format: 00000", "This country requires you to choose a State." };
    }
}