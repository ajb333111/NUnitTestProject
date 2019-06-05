using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class DoublesHome
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public DoublesHome(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // [FindsBy(How = How.CssSelector, Using = "#singlesRanking > div > table > tbody > tr:nth-child(5) > td:nth-child(4) > a")]
        // private IWebElement fifthRankedPlayerInfo;

        private readonly By fifthRankedPlayerInfo = By.CssSelector("#singlesRanking > div > table > tbody > tr:nth-child(5) > td:nth-child(4) > a");

        public PlayerInfoPage goToPlayersBio()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(fifthRankedPlayerInfo)).Click();
            return new PlayerInfoPage(driver);
        }
    }
}