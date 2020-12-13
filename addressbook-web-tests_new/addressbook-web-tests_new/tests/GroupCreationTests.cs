using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {    
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("New Group 1");
            group.Header = "aaa";
            group.Footer = "bbb";

            List<GroupData> oldGroups = appmanager.Groups.GetGroupList();

            appmanager.Groups.Create(group);

            List <GroupData> newGroups  = appmanager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); 
        }

        [Test]
        public void Emptygroupcreationtest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = appmanager.Groups.GetGroupList();

            appmanager.Groups.Create(group);

            List<GroupData> newGroups = appmanager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }        
    }
}
