using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "Новая группа"
            };
            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            int id = app.Groups.GetGroupId(newGroup);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreNotEqual(oldGroups, newGroups);

            app.Groups.Remove(id);
            newGroups = app.Groups.GetGroupList();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
