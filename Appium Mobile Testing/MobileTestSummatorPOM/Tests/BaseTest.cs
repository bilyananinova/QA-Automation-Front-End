using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileTestSummatorPOM.Tests
{
    public class BaseTest
    {

        private const string ApiumServerUri = "http://127.0.0.1:4723/wd/hub";
        private string appPath = @"D:\SoftUni\QA Automation Front-End - march 2023\06. Appium Mobile Testing/com.example.androidappsummator.apk";
        protected AndroidDriver<AndroidElement> driver;


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
    }
}