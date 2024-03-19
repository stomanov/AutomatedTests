using OpenQA.Selenium;
using WebDriver = SeleniumProject.BaseProject.WebDriver;
using WebElement = SeleniumProject.BaseProject.WebElement;

public static class TestExtensions
{
    public static WebElement ScrollToElement(this WebDriver driver, WebElement element)
    {
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
        return element;
    }

    public static string GetCssColor(this IWebElement element)
    {
        return element.GetCssValue("background-color");
    }
}

