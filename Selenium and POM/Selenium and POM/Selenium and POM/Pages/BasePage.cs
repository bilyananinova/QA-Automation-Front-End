using OpenQA.Selenium;

namespace SeleniumAndPOM.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        private string BaseUrl = "https://brandy-shop.web.app/";

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual string BaseUrl { get; }

        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
        public IWebElement AddStudentsLink => driver.FindElement(By.LinkText("Add Student"));

        public void Open()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public string GetPageTitle() 
        {
            return driver.Title;
        }
    }
}
