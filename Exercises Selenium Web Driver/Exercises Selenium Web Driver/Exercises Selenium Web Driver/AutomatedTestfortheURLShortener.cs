using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumExercises
{
    public class AutomatedTestfortheURLShortener
    {

        private WebDriver driver;
        private const string BaseUrl = "https://shorturl.softuniqa.repl.co/";

        IWebElement linkShortUrl;
        WebDriverWait wait;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Url = BaseUrl; ;
            driver.Manage().Window.Maximize();

            linkShortUrl = driver.FindElement(By.LinkText("Short URLs"));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void TestHomePage()
        {
            driver.FindElement(By.LinkText("Home")).Click();
            Assert.That(driver.Title, Contains.Substring("URL Shortener"));
        }

        [Test]
        public void TestShortURLsPage()
        {
            var expextedTitle = driver.FindElement(By.CssSelector("body > main > h1")).Text;

            Assert.That(expextedTitle, Is.EqualTo(driver.Title));
        }

        [Test]
        public void TableTest()
        {
            linkShortUrl.Click();

            var expextedTable = wait.Until(d =>
            {
                return d.FindElement(By.CssSelector("table tr td"));
            });
            Assert.That(expextedTable.Displayed);

        }

        [Test]
        public void FirstCellTest()
        {
            linkShortUrl.Click();

            var firstCellText = driver.FindElement(By.CssSelector("table tr > td")).Text;
            Assert.That(firstCellText.Contains("https://nakov.com"));

        }


        [Test]
        public void SecondCellTest()
        {
            linkShortUrl.Click();

            var secondCellText = driver.FindElement(By.CssSelector("tbody > tr:nth-child(1) > td:nth-child(2)")).Text;
            Assert.That(secondCellText.Contains("http://shorturl.softuniqa.repl.co/go/nak"));

        }
    }
}