using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { } 
        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Management.GoToManagePage();

            GoToManageProjectPage();
            InitNewProject();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }
        public ProjectManagementHelper Remove()
        {
            manager.Management.GoToManagePage();
            GoToManageProjectPage();
            GoToEditProject();
            RemoveProject();
            return this;
        }
        public ProjectManagementHelper GoToManageProjectPage()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
            return this;
        }
        public ProjectManagementHelper InitNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }
        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
            return this;
        }
        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }
        public ProjectManagementHelper GoToEditProject()
        {
            driver.FindElement(By.CssSelector("td > a")).Click();
            return this;
        }
        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }
    }
}
