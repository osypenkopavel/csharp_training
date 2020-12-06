using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Modified Group 2");
            newData.Header = "aaa2";
            newData.Footer = "bbb2";

            GroupData group = new GroupData("New Group 1");
            group.Header = "aaa1";
            group.Footer = "bbb1";

            appmanager.Groups.Modify(1, newData, group);
        }
    }
}
