using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileTestSummatorPOM.Pages
{
    public class Summator
    {
        protected AppiumDriver<AndroidElement> driver;

        public Summator(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        AndroidElement firstField => driver.FindElementById("com.example.androidappsummator:id/editText1");
        AndroidElement secondField => driver.FindElementById("com.example.androidappsummator:id/editText2");
        AndroidElement calcBtn => driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
        AndroidElement result => driver.FindElementById("com.example.androidappsummator:id/editTextSum");

        public string SummatorData(string firstValue, string secondValue)
        {
            firstField.Clear();
            secondField.Clear();

            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcBtn.Click();

            return result.Text;
        }
    }
}
