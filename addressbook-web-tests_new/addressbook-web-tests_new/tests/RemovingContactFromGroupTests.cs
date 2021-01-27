using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestRemovingContactToGroup()
        {
            appmanager.Contacts.IfGroupOrContactIsAbsentCreateThem();
            appmanager.Contacts.IfContactIsAbsentInGroupProvideContactToGroup();            

            appmanager.Contacts.TestRemovingContactFromGroup(appmanager.Contacts.GetCurrentContactData(),
                appmanager.Contacts.GetCurrentGroupData());

            appmanager.Contacts.PrepareActualAndExpectedContactsListsToComparisonAfterDelete();
            Assert.AreEqual(
                appmanager.Contacts.GetContactsFromGroup(),
                appmanager.Contacts.GetListForComparison()
                );            
        }
    }
}
