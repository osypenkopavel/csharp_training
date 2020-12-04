using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            appmanager.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            appmanager.Auth.Login(account);

            //verification
            Assert.IsTrue(appmanager.Auth.IsLoggedIn(account)); 
        }

        [Test]
        public void LoginWithinValidCredentials()
        {
            //prepare
            appmanager.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "123456");
            appmanager.Auth.Login(account);

            //verification
            Assert.IsFalse(appmanager.Auth.IsLoggedIn(account));
        }
    }
}
