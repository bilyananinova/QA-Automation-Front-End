using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo
{
    public class TestsDemo
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://wikipedia.org";

        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void CorrectSearchUrl()
        {

            var inputField = driver.FindElement(By.XPath("//input[@id='searchInput']"));
            inputField.SendKeys("QA");
            inputField.SendKeys(Keys.Enter);

            Assert.That("https://en.wikipedia.org/wiki/QA", Is.EqualTo(driver.Url));

        }

        [Test]
        public void ResultSearchTitle()
        {
            var inputField = driver.FindElement(By.XPath("//input[@id='searchInput']"));
            inputField.SendKeys("QA");
            inputField.SendKeys(Keys.Enter);

            var pageTitle = driver.Title;
            var expectedTitle = "QA - Wikipedia";
            Assert.That(pageTitle, Is.EqualTo(expectedTitle));
        }

    }
}