using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("New Group 1");
            group.Header = "aaa1";
            group.Footer = "bbb1";

            appmanager.Nav.GoToGroupsPage();
            appmanager.Groups.CreateGroupIfAbsent(group);

            List<GroupData> oldGroups = appmanager.Groups.GetGroupList();

            appmanager.Groups.Remove(0);

            List<GroupData> newGroups = appmanager.Groups.GetGroupList();


            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in newGroups)
            {
                Assert.AreNotEqual(groups.Id, toBeRemoved.Id);
            }
        }                           
    }
}
