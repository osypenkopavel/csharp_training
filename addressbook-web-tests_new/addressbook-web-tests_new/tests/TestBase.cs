using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {               
        protected ApplicationManager appmanager;

        [SetUp]
        public void SetupTest()
        {
            appmanager = new ApplicationManager();
            appmanager.Nav.OpenHomePage();
            appmanager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appmanager.Stop();            
        }            
    }
}
