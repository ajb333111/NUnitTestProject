using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class ATPHome
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By rankingsHome = By.CssSelector("div.atp-nav-wrap-inner > nav > ul > li:nth-child(3) > a");
        private By shopIcon = By.CssSelector("a.shop-link");
        private By languageSelector = By.Id("languageSelector");
        private By spanishSelector = By.CssSelector("a[data-language-code='es']");
        private By searchIcon = By.Id("controlSearch");
        private By searchBar = By.CssSelector("#siteSearch > input");
        private By newsIcon = By.CssSelector("#playersWrapper > div > div:nth-child(3) > div > div > a:nth-child(2)");
        private By cookieClose = By.ClassName("cookie-close");
        public ATPHome(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // PageFactory.InitElements(driver, this); //Could not find a fix for PageFactory
        }

        // [FindsBy(How = How.CssSelector, Using = "div.atp-nav-wrap-inner > nav > ul > li:nth-child(3) > a")]
        // private IWebElement rankingsHome;

        public void loadPage()
        {         
            driver.Navigate().GoToUrl("https://www.atptour.com/");
            driver.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.ElementIsVisible(cookieClose));
            wait.Until(ExpectedConditions.ElementToBeClickable(cookieClose)).Click();
        }

        public RankingsHome goToRankingsHomePage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(rankingsHome)).Click();
            return new RankingsHome(driver);
        }

       public SpanishHome goToSpanishHomePage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(languageSelector)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(spanishSelector)).Click();
            return new SpanishHome(driver);
        }

        public News searchPlayerNews(string text)
        {  
            driver.FindElement(searchIcon).Click();
            driver.FindElement(searchBar).SendKeys(text);
            wait.Until(ExpectedConditions.ElementToBeClickable(newsIcon)).Click();
            return new News(driver);
        }

    }

    
}
