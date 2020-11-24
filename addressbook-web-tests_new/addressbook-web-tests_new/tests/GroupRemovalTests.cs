using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            appmanager.Nav.OpenHomePage();
            appmanager.Auth.Login(new AccountData ("admin", "secret"));
            appmanager.Nav.GoToGroupsPage();
            appmanager.Groups.SelectGroup(1);
            appmanager.Groups.RemoveGroup();
            appmanager.Groups.ReturnToGroupsPage();
        }      
                       
    }
}
