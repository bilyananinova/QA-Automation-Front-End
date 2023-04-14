using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktopTestingExercises
{
    public class DesktopTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Program Files\7-Zip\7zFM.exe";
        private const string directory = @"C:\Users\Admin\Desktop\Demo";
        private WindowsDriver<WindowsElement> driver;
        private WindowsDriver<WindowsElement> archiveDriver;
        private AppiumOptions options;
        private AppiumOptions archiveOptions;

        [SetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appLocation);
            options.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            this.archiveOptions = new AppiumOptions();
            archiveOptions.AddAdditionalCapability("app", "Root");
            archiveOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.archiveDriver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), archiveOptions);
            archiveDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
                Thread.Sleep(1000);
            }

            Directory.CreateDirectory(directory);
            Thread.Sleep(1000);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            var inputField = driver.FindElementByClassName("Edit");
            inputField.SendKeys(@"C:\Program Files\7-Zip");
            inputField.SendKeys(Keys.Enter);

            var listItems = driver.FindElementByClassName("SysListView32");
            listItems.SendKeys(Keys.Control + "a");

            var addBtn = driver.FindElementByName("Add");
            addBtn.Click();

            Thread.Sleep(500);
            var archiveWindow = archiveDriver.FindElementByName("Add to Archive");
            var archiveName = archiveWindow.FindElementByXPath("/Window/ComboBox/Edit[@Name='Archive:']");
            archiveName.SendKeys(@"C:\Users\Admin\Desktop\Demo\archive.7z");

            var dropdownArchiveFormat = archiveWindow.FindElementByXPath("/Window/ComboBox[@Name='Archive format:']");
            dropdownArchiveFormat.SendKeys("7z");

            var dropdownArchiveComprasionLevel = archiveWindow.FindElementByXPath("/Window/ComboBox[@Name='Compression level:']");
            dropdownArchiveComprasionLevel.SendKeys("9 - Ultra");

            var dropdownArchiveComprasionMethod = archiveWindow.FindElementByXPath("/Window/ComboBox[@Name='Compression method:']");
            dropdownArchiveComprasionMethod.SendKeys("* LZMA2");

            Thread.Sleep(5000);
            var okBtn = archiveDriver.FindElementByName("OK");
            okBtn.Click();

            Thread.Sleep(5000);
            inputField = driver.FindElementByClassName("Edit");
            inputField.SendKeys(@"C:\Users\Admin\Desktop\Demo\archive.7z");
            inputField.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
            var extractBtn = driver.FindElementByName("Extract");
            extractBtn.Click();

            Thread.Sleep(5000);
            var okButton = driver.FindElementByName("OK");
            okButton.Click();

            Thread.Sleep(5000);
            var executableString = @"C:\Program Files\7-Zip\7zFM.exe";
            var extractedString = @"C:\Users\Admin\Desktop\Demo\7zFM.exe";

            FileAssert.AreEqual(executableString, extractedString);
        }
    }
}

