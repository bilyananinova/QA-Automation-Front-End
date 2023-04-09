using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using AppiumDesktopSummatorPOM.Pages;

namespace AppiumDesktopSummatorPOM.Tests
{
    public class AppiumDesktopSummatorAppTestPOM : BaseTest
    {
        private SummatorPage page;

        [SetUp]
        public void OpenApp()
        {
            this.page = new SummatorPage(driver);
        }

        [TestCase("5", "10", "15")]
        [TestCase("-15", "-15", "-30")]
        [TestCase("-15", "10", "-5")]
        [TestCase("15", "-10", "5")]
        [TestCase("str", "5", "error")]
        [TestCase("5", "str", "error")]
        public void SumValidData(string firstValue, string secondValue, string expectedResult)
        {
            var actualResult = page.SumWithValidData(firstValue, secondValue);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            
        }
    }
}