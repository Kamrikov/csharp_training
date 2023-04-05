using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected ManagementMenuHelper managementMenuHelper;

    [SetUp]
    public void SetupTest()
    {
        driver = new FirefoxDriver();
        baseURL = "http://localhost:8080/mantisbt-2.25.6";
        verificationErrors = new StringBuilder();

        loginHelper = new LoginHelper(driver, baseURL);
        managementMenuHelper = new ManagementMenuHelper(driver);
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

    protected void GoToManageProjectPage()
    {
        driver.FindElement(By.LinkText("Управление проектами")).Click();
    }
    protected void InitNewProject()
    {
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
    }
    protected void FillProjectForm(ProjectData project)
    {
        driver.FindElement(By.Id("project-name")).Clear();
        driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
        driver.FindElement(By.Id("project-description")).Clear();
        driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
    }
    protected void SubmitProjectCreation()
    {
        driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
    }
    protected void GoToEditProject()
    {
        driver.FindElement(By.CssSelector("td > a")).Click();
    }
    protected void RemoveProject()
    {
        driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
    }



    

        /*
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
        */
    }
    
}
