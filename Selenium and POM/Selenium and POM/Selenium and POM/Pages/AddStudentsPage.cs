using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAndPOM.Pages
{
    public class AddStudentsPage : BasePage
    {
        public AddStudentsPage(WebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/add-student";

        public IWebElement NameField => driver.FindElement(By.Id("name"));
        public IWebElement EmailField => driver.FindElement(By.Id("email"));
        public IWebElement AddBtn => driver.FindElement(By.TagName("button"));
        public IWebElement ErrorMsg => driver.FindElement(By.TagName("div"));

        public void SendValidStudentInfo(string name, string email)
        {
            NameField.SendKeys(name);
            EmailField.SendKeys(email);
            AddBtn.Click();
        }

        public void SendInvalidStudentInfo()
        {
            NameField.SendKeys("");
            EmailField.SendKeys("");
            AddBtn.Click();
        }

    }
}
