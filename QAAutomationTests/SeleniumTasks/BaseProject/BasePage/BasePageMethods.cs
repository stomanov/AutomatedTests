using OpenQA.Selenium;

namespace SeleniumProject.BaseProject
{
    public partial class BasePage
    {
        public void ScrollTo(WebElement element)
        {
            ((IJavaScriptExecutor)Driver.GetIWebDriver()).ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
        }

        public void ScrollUp(int pixels)
        {
            ((IJavaScriptExecutor)Driver.GetIWebDriver()).ExecuteScript($"window.scrollBy(0, {-pixels})");
        }

        public void ScrollDown(int pixels)
        {
            ((IJavaScriptExecutor)Driver.GetIWebDriver()).ExecuteScript($"window.scrollBy(0, {pixels})");
        }

        public void ScrollToTopOfThePage()
        {
            ((IJavaScriptExecutor)Driver.GetIWebDriver()).ExecuteScript($"window.scrollTo(0, 0);");
        }

        public void ScrollToBottomOfThePage()
        {
            ((IJavaScriptExecutor)Driver.GetIWebDriver()).ExecuteScript($"window.scrollTo(0, document.body.scrollHeight);");
        }

        public string GetCssColor(WebElement element)
        {
            return element.GetCssValue("background-color");
        }
    }
}
