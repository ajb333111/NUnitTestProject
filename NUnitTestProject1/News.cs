using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class News
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public News (IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private readonly By newsHeader = By.CssSelector("#categoryListing li > div > h3 > a");

        public string getTextFromHeader()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(newsHeader)).Text;
        }
    }
}
