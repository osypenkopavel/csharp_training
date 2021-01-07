using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {            

            GroupData group = new GroupData("New Group 1");
            group.Header = "aaa1";
            group.Footer = "bbb1";
            GroupData newData = new GroupData("Modified Group 2");
            newData.Header = "aaa2";
            newData.Footer = "bbb2";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            appmanager.Nav.GoToGroupsPage();
            appmanager.Groups.CreateGroupIfAbsent(group);          
            appmanager.Groups.Modify(oldData, newData);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in newGroups)
            {
                if (groups.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groups.Name);
                }
            }
        }
    }
}
