using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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
            appmanager.Groups.Remove(1);
        }                           
    }
}
