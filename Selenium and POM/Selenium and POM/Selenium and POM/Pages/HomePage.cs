using OpenQA.Selenium;

namespace SeleniumAndPOM.Pages
{
    public class HomePage : BasePage
    {
        //private readonly IWebDriver driver;

        public HomePage(WebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/";

        public IWebElement StudentCountLabel => driver.FindElement(By.CssSelector("body > p"));

        //public string GetStudentCount()
        //{
        //    Console.WriteLine(StudentCountLabel.Text);
        //    return StudentCountLabel.Text;
        //}
    }
}
