using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SummatorOfNumbers
{
    public class SummatorTests
    {
        private WebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void SumIntegers()
        {
            var inputA = driver.FindElement(By.XPath("//input[@id='number1']"));
            var inputB = driver.FindElement(By.XPath("//input[@id='number2']"));
            var calBtn = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            var operation = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"operation\"]")));

            inputA.SendKeys("1");
            inputB.SendKeys("2");
            operation.SelectByValue("+");
            calBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var resultString = "Result: 3";
            Assert.That(resultString, Is.EqualTo(resultText));

            var result = driver.FindElement(By.XPath("//*[@id=\"result\"]/pre")).Text;
            var resultNumber = "3";
            Assert.That(resultNumber, Is.EqualTo(result));

        }

        [Test]
        public void SumFloatingPointnumbers()
        {
            var inputA = driver.FindElement(By.XPath("//input[@id='number1']"));
            var inputB = driver.FindElement(By.XPath("//input[@id='number2']"));
            var calBtn = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            var operation = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"operation\"]")));

            inputA.SendKeys("1.5");
            inputB.SendKeys("2.5");
            operation.SelectByValue("+");
            calBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var resultString = "Result: 4";
            Assert.That(resultString, Is.EqualTo(resultText));

        }

        [Test]
        public void SumStringWithNumber()
        {
            var inputA = driver.FindElement(By.XPath("//input[@id='number1']"));
            var inputB = driver.FindElement(By.XPath("//input[@id='number2']"));
            var calBtn = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            var operation = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"operation\"]")));

            inputA.SendKeys("3");
            inputB.SendKeys("hello");
            operation.SelectByValue("+");
            calBtn.Click();

            var resultText = driver.FindElement(By.XPath("//*[@id=\"result\"]/i")).Text;
            var result = "invalid input";
            Assert.That(result, Is.EqualTo(resultText));
        }

        [Test]
        public void SubstractIntegers()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("5");
            inputB.SendKeys("2");
            operation.SelectByValue("-");
            calcBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var expectedResult = "Result: 3";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        public void SubstractFloatingPointNumbers()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("6.3");
            inputB.SendKeys("2.2");
            operation.SelectByValue("-");
            calcBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var expectedResult = "Result: 4.1";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void SubstractIntegerWithString()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("str");
            inputB.SendKeys("5");
            operation.SelectByValue("-");
            calcBtn.Click();

            var resultText = driver.FindElement(By.Id("result")).Text;
            var expectedResult = "Result: invalid input";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void MultiplyIntegers()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("5");
            inputB.SendKeys("5");
            operation.SelectByValue("*");
            calcBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var expectedResult = "Result: 25";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void MultiplyFloatingPointNumbers()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("6.5");
            inputB.SendKeys("2");
            operation.SelectByValue("*");
            calcBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var expectedResult = "Result: 13";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void MultiplyIntegerWithString()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("6");
            inputB.SendKeys("hello");
            operation.SelectByValue("*");
            calcBtn.Click();

            var resultText = driver.FindElement(By.Id("result")).Text;
            var expectedResult = "Result: invalid input";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void DivideIntegers()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("8");
            inputB.SendKeys("2");
            operation.SelectByValue("/");
            calcBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var expectedResult = "Result: 4";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void DivideFloatingPointNumbers()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("5.5");
            inputB.SendKeys("2.2");
            operation.SelectByValue("/");
            calcBtn.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;
            var expectedResult = "Result: 2.5";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }


        [Test]
        public void DivideIntegerWithString()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var calcBtn = driver.FindElement(By.Id("calcButton"));
            var operation = new SelectElement(driver.FindElement(By.TagName("select")));

            inputA.SendKeys("8.5");
            inputB.SendKeys("hello");
            operation.SelectByValue("/");
            calcBtn.Click();

            var resultText = driver.FindElement(By.Id("result")).Text;
            var expectedResult = "Result: invalid input";
            Assert.That(expectedResult, Is.EqualTo(resultText));
        }

        [Test]
        public void ResetFunction()
        {
            var inputA = driver.FindElement(By.Id("number1"));
            var inputB = driver.FindElement(By.Id("number2"));
            var resetBtn = driver.FindElement(By.Id("resetButton"));

            inputA.SendKeys("6");
            inputB.SendKeys("2");
            resetBtn.Click();

            Assert.IsEmpty(inputA.Text);
            Assert.IsEmpty(inputB.Text);
        }
    }
}