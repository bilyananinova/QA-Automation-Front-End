using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktopSummatorPOM.Pages
{
    public class SummatorPage
    {

        private WindowsDriver<WindowsElement> driver;

        public SummatorPage(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;

        }

        public WindowsElement firstField => driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement secondField => driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement result => driver.FindElementByAccessibilityId("textBoxSum");
        public WindowsElement calcBtn => driver.FindElementByAccessibilityId("buttonCalc");

        public string SumWithValidData(string firstValue, string secondValue)
        {
            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcBtn.Click();

            return result.Text;
        }
    }
}
