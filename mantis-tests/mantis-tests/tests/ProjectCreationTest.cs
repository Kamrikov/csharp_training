using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/mantisbt-2.25.6";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ProjectCreationTest()
        {
            GoToLoginPage();
            Login(new AccountData ("administrator", "root"));
            GoToManagePage();
            GoToManageProjectPage();
            InitNewProject();
            FillProjectForm(new ProjectData ("название", "описание"));
            SubmitGroupCreation();
            QuitToLoginPage();
        }

        private void QuitToLoginPage()
        {
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/span")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_create.php");
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        private void InitNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_create_page.php");
        }

        private void GoToManageProjectPage()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }

        private void GoToManagePage()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]/a/i")).Click();
            driver.Navigate().GoToUrl(baseURL + "/manage_overview_page.php");
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.Navigate().GoToUrl(baseURL + "/account_page.php");
        }

        private void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
