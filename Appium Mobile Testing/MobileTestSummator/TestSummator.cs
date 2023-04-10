using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileTestSummator
{
    public class TestSummator
    {

        private const string ApiumServerUri = "http://127.0.0.1:4723/wd/hub";
        private string appPath = @"D:\SoftUni\QA Automation Front-End - march 2023\06. Appium Mobile Testing/com.example.androidappsummator.apk";
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void OpenApp()
        {
            var options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appPath);
            driver = new AndroidDriver<AndroidElement>(new Uri(ApiumServerUri), options);
        }

        [OneTimeTearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [TestCase("5", "5", "10")]
        [TestCase("-5", "5", "0")]
        [TestCase("5", "-5", "0")]
        public void Test_SumWithValidData(string firstValue, string secondValue, string resultValue)
        {
            var firstField = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondField = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var calcBtn = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            var result = driver.FindElementById("com.example.androidappsummator:id/editTextSum");

            firstField.Clear();
            secondField.Clear();

            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcBtn.Click();

            Assert.That(result.Text, Is.EqualTo(resultValue));
        }

        [TestCase("2", "str", "error")]
        [TestCase("str", "2", "error")]
        public void Test_SumWithInvalidData(string firstValue, string secondValue, string resultValue)
        {
            var firstField = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondField = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var calcBtn = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            var result = driver.FindElementById("com.example.androidappsummator:id/editTextSum");

            firstField.Clear();
            secondField.Clear();

            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcBtn.Click();

            Assert.That(result.Text, Is.EqualTo(resultValue));
        }
    }
}