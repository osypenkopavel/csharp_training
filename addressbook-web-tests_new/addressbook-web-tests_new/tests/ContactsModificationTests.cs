using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsModificationTests : AuthTestBase 
    {
        [Test]
        public void ContactsModificationTest()
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

            ContactData newData = new ContactData("John", "Jackson");
            newData.Middlename = "zzz";
            newData.Nickname = "zzz";
            newData.Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif";
            newData.Title = "zzz";
            newData.Company = "zzz";
            newData.Address = "zzz";
            newData.Home = "zzz";
            newData.Mobile = "zzz";
            newData.Work = "zzz";
            newData.Fax = "zzz";
            newData.Email = "zzz";
            newData.Email2 = "zzz";
            newData.Email3 = "zzz";
            newData.Homepage = "zzz";
            newData.Bday = "12";
            newData.Bmonth = "December";
            newData.Byear = "1991";
            newData.Aday = "12";
            newData.Amonth = "December";
            newData.Ayear = "2021";
            newData.Address2 = "zzz";
            newData.Phone2 = "zzz";
            newData.Notes = "zzz";

            appmanager.Contacts.CreateContactIfAbsent(contact);

            List<ContactData> oldContacts = appmanager.Contacts.GetContactList();

            appmanager.Contacts.Modify(0, newData);

            List<ContactData> newContacts = appmanager.Contacts.GetContactList();
            oldContacts[0].Fullname = newData.Fullname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
