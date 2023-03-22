using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CheckForContact();

            ContactData newData = new ContactData("Имя", "Фамилия");

            List<ContactData> oldContacts = ContactData.GetAll(); //app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll(); //app.Contacts.GetContactList();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts) 
            { 
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }
        }
    }
}
