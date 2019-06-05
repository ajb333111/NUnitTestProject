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

        private By newsHeader = By.CssSelector("#categoryListing li > div > h3 > a");
        private By newsName = By.CssSelector("ul.breadcrumb-titles > li");

        public News (IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public string getTextFromHeader()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(newsName)).Text;
        }
    }
}
