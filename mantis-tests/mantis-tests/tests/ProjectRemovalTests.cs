using System;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            loginHelper.GoToLoginPage();
            loginHelper.Login(new AccountData("administrator", "root"));
            managementMenuHelper.GoToManagePage();
            GoToManageProjectPage();
            GoToEditProject();
            RemoveProject();
            loginHelper.QuitToLoginPage();
        }
    }
}
