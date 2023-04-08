using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExercises
{
    public class TestLoginPage
    {

        private WebDriver driver;
        private const string BaseUrl = "https://softuni.bg";

        IWebElement loginBtn;
        WebDriverWait wait;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Url = BaseUrl;
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            loginBtn = driver.FindElement(By.XPath("//a[contains(.,'Вход')]"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void OpenLoginPage()
        {
            loginBtn.Click();
            //bool isFormDisplayed = driver.FindElement(By.TagName("form")).Displayed;
            //Assert.True(isFormDisplayed);

            var expForm = wait.Until(d =>
            {
                return d.FindElement(By.TagName("form")).Displayed;
            });

            Assert.True(expForm);
        }

        [TestCase("username", "password")] //InvalidUsername_InvalidPassword

        public void Login_Function(string username, string password)
        {
            loginBtn.Click();

            var expForm = wait.Until(d =>
            {
                return d.FindElement(By.TagName("form")).Displayed;
            });

            var usernameInput = driver.FindElement(By.Id("username"));
            var passwordInput = driver.FindElement(By.Id("password-input"));
            var submitBtn = driver.FindElement(By.XPath("//input[@type='submit']"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            submitBtn.Click();

            var message = driver.FindElement(By.TagName("li")).Text;

            if (message.Contains("парола"))
            {
                Assert.That(message.Contains("Невалидно потребителско име или парола"));
            }
            else
            {
                var expextedTitle = "Обучение по програмиране - Софтуерен университет";
                Assert.That(driver.Title, Is.EqualTo(expextedTitle));
            }

        }
    }
}