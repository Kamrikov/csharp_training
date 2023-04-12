using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            //ProjectData project = new ProjectData("название9", "описание");
            ProjectData project = new ProjectData(GenerateRandomString(10), "описание");
            
            List<ProjectData> oldProject = app.Project.GetProjectList();

            app.Project.Create(project);

            List<ProjectData> newProject = app.Project.GetProjectList();
            oldProject.Add(project);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);
        }
    }
}
