using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {
            appmanager.Contacts.IfGroupOrContactIsAbsentCreateThem();
            appmanager.Contacts.IfContactWithoutGroupIsAbsentProvideContactWithoutGroup();  

            appmanager.Contacts.AddContactToGroup(appmanager.Contacts.GetCurrentContactData(),
                appmanager.Contacts.GetCurrentGroupData());

            appmanager.Contacts.PrepareActualAndExpectedContactsListsToComparison();            
            Assert.AreEqual(
                appmanager.Contacts.GetContactsFromGroup(),
                appmanager.Contacts.GetListForComparison()
                );            
        }
    }
}
