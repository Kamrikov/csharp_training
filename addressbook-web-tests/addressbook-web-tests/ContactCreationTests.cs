using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBaseContact
    {

        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            ContactData contact = new ContactData
            {
                FirstName = "Ivan",
                LastName = "Sidorov"
            };
            FillContactForm(contact);
            SubmitContactCreation();
            RetornToHomePage();
        }
    }
}
