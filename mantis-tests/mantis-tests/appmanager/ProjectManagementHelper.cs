using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { } 
        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Navigator.GoToManagePage();
            manager.Navigator.GoToManageProjectPage();

            InitNewProject();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }
        public ProjectManagementHelper Remove()
        {
            manager.Navigator.GoToManagePage();
            manager.Navigator.GoToManageProjectPage();

            GoToEditProject();
            RemoveProject();
            return this;
        }
        public ProjectManagementHelper InitNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }
        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
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
