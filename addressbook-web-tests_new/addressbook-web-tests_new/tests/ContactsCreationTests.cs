using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsCreationTests : AuthTestBase
    {
        [Test]
        public void ContactsCreationTest()
        {
             
             ContactData contact = new ContactData("Pavlo", "Osypenko");
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

             appmanager.Contacts.Create(contact);
        }            
    }
}
