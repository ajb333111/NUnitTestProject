using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class PlayerInfoPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        public PlayerInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        // [FindsBy(How = How.CssSelector, Using = "div[data-singles='5']")]
        // private IWebElement five;

        private readonly By rank = By.CssSelector("div[data-doubles='5']");

        public string getRanking()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(rank)).Text;
        }
    }

}