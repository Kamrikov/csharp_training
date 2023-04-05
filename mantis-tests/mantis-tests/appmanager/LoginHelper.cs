using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper
    {
        private IWebDriver driver;
        private string baseURL;
        public LoginHelper(IWebDriver driver, string baseURL)
        {
            this.driver = driver;
            this.baseURL = baseURL;
        }
        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }
        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }
        public void QuitToLoginPage()
        {
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
        }
    }
}
