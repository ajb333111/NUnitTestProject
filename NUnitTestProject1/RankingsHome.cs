using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class RankingsHome
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public RankingsHome (IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // [FindsBy(How = How.CssSelector, Using = "a[data-ga-label='Singles']")]
        // private IWebElement singlesRankings;

        private By doublesRankings = By.CssSelector("#Rankings_subNav > ul > li[data-title='Doubles'] > a");

        public DoublesHome goToSinglesRankings()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(doublesRankings)).Click();
            return new DoublesHome(driver);
        }
    }
}
