using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsModificationTests : TestBase
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

            appmanager.Contacts.Modify(3, newData);
        }
    }
}
