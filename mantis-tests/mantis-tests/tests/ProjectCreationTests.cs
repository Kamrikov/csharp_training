﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            loginHelper.GoToLoginPage();
            loginHelper.Login(new AccountData ("administrator", "root"));
            managementMenuHelper.GoToManagePage();
            GoToManageProjectPage();
            InitNewProject();
            FillProjectForm(new ProjectData ("название5", "описание"));
            SubmitProjectCreation();
            loginHelper.QuitToLoginPage();
        }
    }
}
