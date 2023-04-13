using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using System.Xml.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        AccountData account = new AccountData()
        {
            Username = "administrator",
            Password = "root",
        };

        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData(GenerateRandomString(15), "описание");

            List<ProjectData> oldProject = app.Project.GetProjectList();

            app.Project.Create(project);

            List<ProjectData> newProject = app.Project.GetProjectList();
            oldProject.Add(project);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
        }
        [Test]
        public void ProjectCreationTestAPI()
        {
            ProjectData project = new ProjectData(GenerateRandomString(15), "описание");

            List<ProjectData> oldProject = app.API.GetProjectList(account);

            app.Project.Create(project);

            List<ProjectData> newProject = app.API.GetProjectList(account);
            oldProject.Add(project);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
        }
    }
}
