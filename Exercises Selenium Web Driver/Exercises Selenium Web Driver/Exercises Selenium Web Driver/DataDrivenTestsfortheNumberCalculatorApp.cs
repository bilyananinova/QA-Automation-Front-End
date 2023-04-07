using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExercises
{
    public class DataDrivenTestsfortheNumberCalculatorApp
    {

        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        IWebElement firstField;
        IWebElement secondField;
        SelectElement operationField;
        IWebElement calcBtn;
        IWebElement resultField;
        IWebElement resetBtn;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Url = BaseUrl; ;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            firstField = driver.FindElement(By.XPath("//input[@id='number1']"));
            secondField = driver.FindElement(By.XPath("//input[@id='number2']"));
            operationField = new SelectElement(driver.FindElement(By.XPath("//select[@id='operation']")));
            calcBtn = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            resetBtn = driver.FindElement(By.XPath("//input[@id='resetButton']"));
            resultField = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [TestCase("2", "2", "+", "Result: 4")]
        [TestCase("-5", "-2", "+", "Result: -7")]
        [TestCase("2", "2.2", "+", "Result: 4.2")]
        [TestCase("0", "2", "+", "Result: 2")]

        [TestCase("0", "2", "-", "Result: -2")]
        [TestCase("5", "2", "-", "Result: 3")]
        [TestCase("-5.3", "2.2", "-", "Result: -7.5")]
        [TestCase("-3", "-2", "-", "Result: -1")]

        [TestCase("0", "2", "*", "Result: 0")]
        [TestCase("5", "2", "*", "Result: 10")]
        [TestCase("5.3", "2.2", "*", "Result: 11.66")]
        [TestCase("-3", "-2", "*", "Result: 6")]

        [TestCase("10", "-2", "/", "Result: -5")]
        [TestCase("5", "2.5", "/", "Result: 2")]
        [TestCase("9", "3", "/", "Result: 3")]
        [TestCase("-3", "-2", "/", "Result: 1.5")]

        [TestCase("hello", " ", "+", "Result: invalid input")]
        [TestCase("hello", "2", "/", "Result: invalid input")]
        [TestCase("5", "str", "-", "Result: invalid input")]

        public void TestCalculatorApp(
            string numberA, string numberB, string operation, string result)
        {
            resetBtn.Click();
            firstField.SendKeys(numberA);
            secondField.SendKeys(numberB);
            operationField.SelectByValue(operation);
            calcBtn.Click();

            Assert.That(resultField.Text, Is.EqualTo(result));

            if (result == "Result: invalid input")
            {
                var color = resultField.GetCssValue("color");
                Assert.That("rgba(0, 0, 0, 1)", Is.EqualTo(color));
            }
        }

    }
}
