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
            GroupData newData = new GroupData("тест3");
            newData.Header = "тест3";
            newData.Footer = "тест3";

            app.Groups.Modify(1, newData);
        }
    }
}
