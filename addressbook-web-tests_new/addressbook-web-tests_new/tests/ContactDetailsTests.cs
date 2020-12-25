using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsTests : AuthTestBase
    {
                [Test]
        public void ContactDetailsTest()
        {
            var fromDetails = appmanager.Contacts.GetContactInformationFromDetails(0);
            ContactData fromFullEditForm = appmanager.Contacts.GetContactInformationFromFullEditForm(0);
            
            Assert.AreEqual(fromDetails, fromFullEditForm.AllDetails);
        }

    }
}
