using NUnit.Framework;
using SeleniumAndPOM.Pages;

namespace SeleniumAndPOM.Tests
{
    public class ViewStudentsPageTests : BaseTest
    {

        private ViewStudentsPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new ViewStudentsPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            page.Open();
        }

        [Test]
        public void Test_Title_Page()
        {
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("Students"));

        }

        [Test]
        public void Test_List_Generate()
        {
            var isListDisplayed = page.List.Displayed;
            Assert.IsTrue(isListDisplayed);
        }
    }
}
