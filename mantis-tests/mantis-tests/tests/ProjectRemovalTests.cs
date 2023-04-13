using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        AccountData account = new AccountData()
        {
            Username = "administrator",
            Password = "root",
        };

        [Test]
        public void ProjectRemovalTest()
        {
            app.Project.CheckForProject();

            List<ProjectData> oldProject = app.Project.GetProjectList();

            app.Project.Remove();

            List<ProjectData> newProject = app.Project.GetProjectList();

            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);
        }
        [Test]
        public void ProjectRemovalTestAPI()
        {
            ProjectData project;

            List<ProjectData> oldProject = app.API.GetProjectList(account);

            if (oldProject.Count == 0)
            {
                project = new ProjectData("Новый проект", "Описание");
                app.API.CheckForProject(account, project);
            }

            List<ProjectData> newProject = app.API.GetProjectList(account);

            app.Project.Remove();

            List<ProjectData> newRemoveProject = app.API.GetProjectList(account);

            newProject.RemoveAt(0);
            Assert.AreEqual(newProject, newRemoveProject);
        }
    }
}
