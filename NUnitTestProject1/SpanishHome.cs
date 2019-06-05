using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class SpanishHome
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public SpanishHome (IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private readonly By languageSelector = By.Id("languageSelector");
        private readonly By englishSelector = By.CssSelector("a[data-language-code='en']");

        public ATPHome goToEnglishHomePage()
        {
            driver.FindElement(languageSelector).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(englishSelector)).Click();
            return new ATPHome(driver);
        }


    }
}
