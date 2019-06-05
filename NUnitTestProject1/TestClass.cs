using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnitTestProject1;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Tests
    {

        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outPutDirectory);
        }

        [Test]
        [Description(@"Given I am a tennis fan
                       When I want to find info about the ATP tour
                       Then I load the ATP Tour home page")]
        public void Should_load_home_page()
        {
            ATPHome home = new ATPHome(driver);
            home.loadPage();
            Assert.AreEqual("https://www.atptour.com/", driver.Url);
        }

        [Test]
        [Description(@"Given I am on the ATP Tour home page
                       And I want to find info about 5th ranked male doubles tennis player
                       When I click on 'Rankings'
                       And I click on 'Doubles'
                       And I click on the 5th ranked player's name
                       Then I should be on that player's info page
                       And their doubles rank should be 5")]
        public void Should_find_tennis_player_and_be_on_their_info_page()
        {
            ATPHome home = new ATPHome(driver);
            home.loadPage();
            RankingsHome rankings = home.goToRankingsHomePage();
            DoublesHome doubles = rankings.goToSinglesRankings();
            PlayerInfoPage fifthRankedPlayer = doubles.goToPlayersBio();
            Assert.AreEqual(fifthRankedPlayer.getRanking(), "5");

        }

        [Test]
        [Description(@"Given I am a Spanish Speaker
                       And I am on the ATP english website
                       When I click on the language icon
                       Then I should be able to click the 'Spanish' icon
                       And I should be on the Spanish version ATP home page")]
        public void Should_be_able_to_switch_to_spanish_home_page()
        {
            ATPHome home = new ATPHome(driver);
            home.loadPage();
            SpanishHome shopPage = home.goToSpanishHomePage();
            Assert.AreEqual("https://www.atptour.com/es", driver.Url);
        }

        // Probably not the best kind of test since the first article title could change
        [TestCase("Rafael Nadal", ExpectedResult = "Federer & Nadal's 10 Best Quotes About Each Other")]
        [TestCase("Roger Federer", ExpectedResult = "Federer Puts Up 'Help Wanted' Sign In Paris Ahead Of Nadal Clash")]
        [Description(@"Given my two favorite tennis players are Rafael Nadal and Roger Federer
                       And I am on the ATP home page
                       When I click the 'Search' icon
                       And I type in each of their names
                       And I click on 'News'
                       Then I should see the latest news article for that player")]
        public string Should_be_able_to_find_news_articles_for_a_certain_player(string player)
        {
            ATPHome home = new ATPHome(driver);
            home.loadPage();
            News newsPage = home.searchPlayerNews(player);
            return newsPage.getTextFromHeader();
           
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}