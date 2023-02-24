using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CheckForContact();

            ContactData newData = new ContactData
            {
                FirstName = "тестИзменение",
                LastName = "тестИзменение"
            };

            app.Contacts.Modify(newData);
        }
    }
}
