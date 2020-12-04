using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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

            appmanager.Groups.Create(group);
        }

        //[Test]
        //public void EmptyGroupCreationTest()
        //{

        //    GroupData group = new GroupData("");
        //    group.Header = "";
        //    group.Footer = "";

        //    appmanager.Groups.Create(group);                
        //}
    }
}
