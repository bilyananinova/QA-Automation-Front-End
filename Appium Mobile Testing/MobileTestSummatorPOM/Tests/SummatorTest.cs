using MobileTestSummatorPOM.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;


namespace MobileTestSummatorPOM.Tests
{
    public class SummatorTest : BaseTest
    {
        private Summator page;

        [SetUp]
        public void OpenApp()
        {
            this.page = new Summator(driver);
        }

        [TestCase("5", "5", "10")]
        [TestCase("-5", "5", "0")]
        [TestCase("5", "-5", "0")]
        [TestCase("2", "str", "error")]
        [TestCase("str", "2", "error")]
        public void Test_Sum(string firstValue, string secondValue, string resultValue)
        {
           var result = page.SummatorData(firstValue, secondValue);

            Assert.That(result, Is.EqualTo(resultValue));
        }
    }
}
