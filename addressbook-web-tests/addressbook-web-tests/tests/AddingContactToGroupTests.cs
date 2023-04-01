using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Groups.CheckForGroup();
            app.Contacts.CheckForContact();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacs();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
           
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacs();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
