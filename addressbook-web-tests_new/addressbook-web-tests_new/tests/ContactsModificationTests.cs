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

            ContactData contact = new ContactData("Pavlo2", "Osypenko2");
            contact.Middlename = "n/a";
            contact.Nickname = "posypenko";
            contact.Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif";
            contact.Title = "New Contact 1";
            contact.Company = "Co";
            contact.Address = "Ukraine, Kyiv, Streetside str.123, office 2B";
            contact.Home = "+380442222222";
            contact.Mobile = "+0972222222";
            contact.Work = "+0443333333";
            contact.Fax = "+0443333333";
            contact.Email = "posypenko@gmail.com";
            contact.Email2 = "posypenko+2@gmail.com";
            contact.Email3 = "posypenko+3@gmail.com";
            contact.Homepage = "https://posypenko.com";
            contact.Bday = "2";
            contact.Bmonth = "January";
            contact.Byear = "1991";
            contact.Aday = "2";
            contact.Amonth = "January";
            contact.Ayear = "2001";
            contact.Address2 = "France, Grenoble, Napoleon str. 123";
            contact.Phone2 = "+332222222";
            contact.Notes = "Contact #1 created";

            appmanager.Contacts.Modify(1, newData, contact);
        }
    }
}
