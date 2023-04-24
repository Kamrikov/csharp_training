using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovContactFromGroupTest()
        {
            
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
            /*
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
            */
        }
    }
}
