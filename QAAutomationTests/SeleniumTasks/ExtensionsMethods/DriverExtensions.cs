using OpenQA.Selenium;
using SeleniumTasks.Core;

public static class DriverExtensions
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

    public static void ScrollUp(this WebDriver driver, int pixels)
    {
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript($"window.scrollBy(0, {-pixels})");
    }

    public static void ScrollDown(this WebDriver driver, int pixels)
    {
        ((IJavaScriptExecutor)driver.WrappedDriver).ExecuteScript($"window.scrollBy(0, {pixels})");
    }
}

