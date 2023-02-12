using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData
            {
                FirstName = "Fedor",
                LastName = "Budkin"
            };
            app.Contacts.Modify(22, newData);
        }
    }
}
