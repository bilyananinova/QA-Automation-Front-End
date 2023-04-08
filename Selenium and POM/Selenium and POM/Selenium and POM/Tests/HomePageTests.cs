using NUnit.Framework;
using SeleniumAndPOM.Pages;

namespace SeleniumAndPOM.Tests
{
	public class HomePageTests : BaseTest
	{
		private HomePage page;

		[SetUp]
		public void Setup()
		{
			this.page = new HomePage(driver);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			page.Open();
        }

        [Test]
		public void Test_Title_Page()
		{
			page.Open();
			Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));

		}

        [Test]
        public void Test_Register_InfoText()
        {
			var expectedText = "Registered students:";
			var actualText = page.StudentCountLabel.Text;

			Assert.That(actualText.Contains(expectedText));

		}
    }
}
