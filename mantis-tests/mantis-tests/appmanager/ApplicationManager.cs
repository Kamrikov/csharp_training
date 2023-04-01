﻿using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
        }
        ~ApplicationManager() //После Лекции 3.2 этот деструктор должен закрывать браузер
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost:8080/mantisbt-2.25.6/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver 
        {
            get 
            { 
                return driver; 
            }
        }
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
    }
}
