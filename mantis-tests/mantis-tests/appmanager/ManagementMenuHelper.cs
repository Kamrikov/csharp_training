using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper
    {
        private IWebDriver driver;
        public ManagementMenuHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToManagePage()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
        }
    }
}
