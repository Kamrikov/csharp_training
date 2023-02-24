using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]

        public void GroupRemovalTest()
        {
            app.Groups.CheckForGroup();
            app.Groups.Remove(1);
        }
    }
}
