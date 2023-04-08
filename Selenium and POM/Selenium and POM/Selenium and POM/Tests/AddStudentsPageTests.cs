using NUnit.Framework;
using SeleniumAndPOM.Pages;

namespace SeleniumAndPOM.Tests
{
    public class AddStudentsPageTests : BaseTest
    {
        private AddStudentsPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new AddStudentsPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            page.Open();
        }

        [Test]
        public void Test_Title_Page()
        {
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("Add Student"));

        }

        [TestCase("Peter", "peter@mail.com")]
        [TestCase("George", "george@mail.com")]
        public void Test_Send_Valid_Student_Info(string name, string email)
        {
            page.SendValidStudentInfo(name, email);
            Assert.That(driver.Title, Is.EqualTo("Students"));
        }

        [Test]
        public void Test_Send_Invalid_Student_Info()
        {
            page.SendInvalidStudentInfo();
            var isErrorMsgDisplayed = page.ErrorMsg.Displayed;
            var content = page.ErrorMsg.Text;

            Assert.True(isErrorMsgDisplayed);
            Assert.That(content.Contains("Cannot add student. Name and email fields are required!"));
        }
    }
}
