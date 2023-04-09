using OpenQA.Selenium;

namespace SeleniumAndPOM.Pages
{
    public class HomePage : BasePage
    {

        public HomePage(WebDriver driver) : base(driver) { }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/";

        public IWebElement StudentCountLabel => driver.FindElement(By.CssSelector("body > p"));

    }
}
