using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace AppiumDesktopSummatorPOM.Tests
{
    public class BaseTest
    {
        private const string appiumServer = "http://[::1]:4723/wd/hub";
        private const string appLocation = @"SummatorDesktopApp.exe";
        protected WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void OpenApp()
        {
            options = new AppiumOptions();
            options.AddAdditionalCapability("app", appLocation);
            options.AddAdditionalCapability("PlatformName", "Windows");
            driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

    }
}
