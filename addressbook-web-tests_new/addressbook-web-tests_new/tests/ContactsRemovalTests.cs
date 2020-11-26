using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsRemovalTests : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            appmanager.Contacts.Remove(3);
        }
    }
}
