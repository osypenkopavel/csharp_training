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
            group.Header = "aaa";
            group.Footer = "bbb";

            appmanager.Groups.Remove(1, group);
        }                           
    }
}
