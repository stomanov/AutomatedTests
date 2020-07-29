using OpenQA.Selenium;
using SeleniumTasks.Core;

namespace SeleniumTasks.Pages.DemoQA
{
    public class SliderPage : DemoQAPage
    {
        public SliderPage(WebDriver driver) : base(driver)
        {
        }

        public WebElement Slider => Driver.FindClickableElement(By.XPath("//*[@id='sliderContainer']//input[contains(@class, 'range-slider')]"));

        public WebElement SliderValue => Driver.FindExistingElement(By.XPath("//*[@id='sliderValue']"));

        public WebElement SliderToolTip => Driver.FindExistingElement(By.XPath("//*[@id='sliderContainer']//div[contains(@class, 'tooltip__label')]"));

        public void Slide()
        {
            Builder.DragAndDropToOffset(Slider.WrappedElement, 200, 0).Perform();
        }
    }
}