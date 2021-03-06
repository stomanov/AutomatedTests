﻿using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks.Core;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTasks.Pages.DemoQA.SelectablePage
{
    public class SelectablePage : BasePage
    {
        public SelectablePage(WebDriver driver) : base (driver)
        {
        }

        public WebElement ListTab => Driver.FindElement(By.XPath("//*[@id='demo-tab-list']"));

        public WebElement GridTab => Driver.FindElement(By.XPath("//*[@id='demo-tab-grid']"));

        public List<WebElement> ListOfSentences => Driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//li[contains(@class, 'list-group-item')]")).ToList();

        public List<WebElement> GridOfNumbers => Driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(@class, 'list-group-item')]")).ToList();

        public void AssertColorsBeforeAndAfter(string colorBefore, string colorAfter)
        {
            Assert.AreNotEqual(colorBefore, colorAfter);
        }
    }
}