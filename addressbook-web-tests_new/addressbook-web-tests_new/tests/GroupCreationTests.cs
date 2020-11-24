using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {    
        [Test]
        public void GroupCreationTest()
        {
            appmanager.Nav.OpenHomePage();
            appmanager.Auth.Login(new AccountData("admin", "secret"));
            appmanager.Nav.GoToGroupsPage();
            appmanager.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("New Group 1");
            group.Header = "aaa";
            group.Footer = "bbb";
            appmanager.Groups.FillGroupForm(group);
            appmanager.Groups.SubmitGroupCreation();
            appmanager.Groups.ReturnToGroupsPage();
            appmanager.Auth.Logout();
        }                             
    }
}
