﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactsRemovalTest()
        {
            ContactData contact = new ContactData("Test", "Test");
            contact.Middlename = "zzz";
            contact.Nickname = "zzz";
            contact.Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif";
            contact.Title = "zzz";
            contact.Company = "zzz";
            contact.Address = "zzz";
            contact.Home = "zzz";
            contact.Mobile = "zzz";
            contact.Work = "zzz";
            contact.Fax = "zzz";
            contact.Email = "zzz";
            contact.Email2 = "zzz";
            contact.Email3 = "zzz";
            contact.Homepage = "zzz";
            contact.Bday = "12";
            contact.Bmonth = "December";
            contact.Byear = "1991";
            contact.Aday = "12";
            contact.Amonth = "December";
            contact.Ayear = "2021";
            contact.Address2 = "zzz";
            contact.Phone2 = "zzz";
            contact.Notes = "zzz";

            appmanager.Contacts.CreateContactIfAbsent(contact);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            appmanager.Contacts.Remove(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }
        }
    }
}
