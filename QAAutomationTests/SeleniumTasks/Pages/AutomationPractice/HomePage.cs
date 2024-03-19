using AutoFixture;
using OpenQA.Selenium;
using SeleniumProject.BaseProject;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

namespace SeleniumProject.Pages.AutomationPractice
{
    public class HomePage : BasePage
    {
        public HomePage(WebDriver driver) : base(driver) { }

        public override string URL => "http://automationpractice.com/";

        public WebElement SignInHeader => Driver.FindClickableElement(By.XPath("//*[@id='header']//a[@class='login']"));

        public WebElement EmailInput => Driver.FindExistingElement(By.XPath("//*[@id='email_create']"));

        public WebElement SignInButton => Driver.FindClickableElement(By.XPath("//*[@id='SubmitCreate']"));

        public void SignUp()
        {
            var fixture = new Fixture();
            var randomEmail = fixture.Create<string>() + "@gmail.com";

            EmailInput.FillText(randomEmail);
            SignInButton.WaitAndClick();
        }
    }
}