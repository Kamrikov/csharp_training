﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("тест2");
            group.Header = "тест2";
            group.Footer = "тест2";
            FillGroupForm(group);
            SubmitGroupCreation();
            RetornToGroupsPage();
            Logout();
        }
    }
}
