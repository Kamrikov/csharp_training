using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData
            {
                FirstName = "Iva",
                LastName = "Sidorov"
            };

            app.Contacts.Create(contact);
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData
            {
                FirstName = "",
                LastName = ""
            };

            app.Contacts.Create(contact);
        }
    }
}
