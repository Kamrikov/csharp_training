using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddRemoveContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroupTest()
        {
            
            app.Groups.CheckForGroup();
            app.Contacts.CheckForContact();

            /*
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacs();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
           
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacs();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
            */

            var contacts = ContactData.GetAll();
            var groups = GroupData.GetAll();

            ContactData targetContact = null;
            GroupData targetGroup = null;
            var found = false;
            foreach (var contact in contacts)
            {
                foreach (var group in groups)
                {
                    if (!group.GetContacts().Contains(contact))
                    {
                        targetContact = contact;
                        targetGroup = group;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            if (!found)
            {
                app.Contacts.Create(new ContactData(GenerateRandomString(8), GenerateRandomString(12)));
                var tempContacts = ContactData.GetAll();
                targetContact = tempContacts.Except(contacts).First();
                targetGroup = groups[0];
            }
            var oldList = targetGroup.GetContacts();
            app.Contacts.AddContactToGroup(targetContact, targetGroup);
            List<ContactData> newList = targetGroup.GetContacts();
            oldList.Add(targetContact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void RemovContactFromGroupTest()
        {
            var groups = GroupData.GetAll();
            if (!groups.Any())
                app.Groups.CheckForGroup();
            var targetGroup = groups.FirstOrDefault(g => g.GetContacts().Any());
            if (targetGroup == default)
            {
                AddContactToGroupTest();
                targetGroup = groups.FirstOrDefault(g => g.GetContacts().Any());
                Assert.NotNull(targetGroup);
            }
            var oldList = targetGroup.GetContacts();
            var contact = oldList[0];
            app.Contacts.RemoveContactFromGroup(contact, targetGroup);

            var newList = targetGroup.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
