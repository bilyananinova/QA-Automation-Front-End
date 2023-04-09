using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktopDemo.Tests
{
    public class AppiumDesktopSummatorAppTest
    {
        private const string appiumServer = "http://[::1]:4723/wd/hub";
        private const string appLocation = @"D:\SoftUni\QA Automation Front-End - march 2023\05. Appium Desktop Testing\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void OpenApp()
        {
            options = new AppiumOptions();
            options.AddAdditionalCapability("app", appLocation);
            options.AddAdditionalCapability("PlatformName", "Windows");
            driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();

        }

        [TestCase("5", "10", "15")]
        [TestCase("-15", "-15", "-30")]
        [TestCase("-15", "10", "-5")]
        [TestCase("15", "-10", "5")]
        public void Test_SumWithValidNumbers(string firstValue, string secondValue, string resultValue)
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var calcBtn = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcBtn.Click();

            Assert.That(result.Text, Is.EqualTo(resultValue));
        }

        [TestCase("str", "5", "error")]
        [TestCase("5", "str", "error")]
        public void Test_SumWithInvalidNumbers(string firstValue, string secondValue, string resultValue)
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var calcBtn = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcBtn.Click();

            Assert.That(result.Text, Is.EqualTo(resultValue));
        }
    }
}