using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Groups.CheckingForGroup();

            GroupData newData = new GroupData("тестИзменение");
            newData.Header = "тестИзменение";
            newData.Footer = "тестИзменение";

            app.Groups.Modify(1, newData);
        }
    }
}
