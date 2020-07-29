using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTasks.Pages.DemoQA
{
    public class AutoCompletePage : DemoQAPage
    {
        public AutoCompletePage(WebDriver driver) : base(driver)
        {
        }

        public WebElement MultiColorNameField => Driver.FindExistingElement(By.XPath("//*[@id='autoCompleteMultipleInput']"));

        public WebElement SingleColorNameField => Driver.FindExistingElement(By.XPath("//*[@id='autoCompleteSingleInput']"));

        public WebElement RedColorAutoCompleteInSingleColor => Driver.FindExistingElement(By.XPath("//*[@id='react-select-3-option-0']"));
        
        public WebElement GreenColorAutoCompleteInSingleColor => Driver.FindExistingElement(By.XPath("//*[@id='react-select-3-option-1']"));

        public WebElement RedColorAutoCompleteInMultiColor => Driver.FindExistingElement(By.XPath("//*[@id='react-select-2-option-0']"));

        public WebElement GreenColorAutoCompleteInMultiColor => Driver.FindExistingElement(By.XPath("//*[@id='react-select-2-option-1']"));

        public List<WebElement> ListOfColorsInMultiColor => Driver.FindElements(By.XPath("//*[@id='autoCompleteMultipleContainer']/div[2]/div")).ToList();

        public void TypingOnceInMultiColorNameField(string colorName)
        {
            MultiColorNameField.Click();
            MultiColorNameField.SendKeys(colorName);
            MultiColorNameField.SendKeys(Keys.Enter);
        }

        public void TypingOnceInSingleColorNameField(string colorName)
        {
            Builder.Click(SingleColorNameField.WrappedElement).SendKeys(colorName).Perform();
        }

        public void TypingTwiceInMultiColorNameField(string colorName, string secondType)
        {
            MultiColorNameField.Click();
            MultiColorNameField.SendKeys(colorName);
            MultiColorNameField.SendKeys(Keys.Enter);
            MultiColorNameField.SendKeys(secondType);
        }

        public void AssertColorsNamesAreDisplayed()
        {
            Assert.IsTrue(RedColorAutoCompleteInSingleColor.Displayed);
            Assert.IsTrue(GreenColorAutoCompleteInSingleColor.Displayed);
        }

        public void AssertColorNameIsDisplayed(bool? trueCondition)
        {
            Assert.IsTrue(trueCondition);
        }

        public void AssertColorsNamesAreTheSameAsDisplayed()
        {
            Assert.AreEqual("Red", RedColorAutoCompleteInSingleColor.Text);
            Assert.AreEqual("Green", GreenColorAutoCompleteInSingleColor.Text);
        }
    }
}