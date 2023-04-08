using OpenQA.Selenium;

namespace SeleniumAndPOM.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(WebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/students";

        public IWebElement List => driver.FindElement(By.CssSelector("body > ul"));
    }
}
