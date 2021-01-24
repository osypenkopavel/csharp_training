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
            ContactData addcontact = new ContactData("Test", "Test");
            addcontact.Middlename = "zzz";
            addcontact.Nickname = "zzz";
            addcontact.Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif";
            addcontact.Title = "zzz";
            addcontact.Company = "zzz";
            addcontact.Address = "zzz";
            addcontact.Home = "zzz";
            addcontact.Mobile = "zzz";
            addcontact.Work = "zzz";
            addcontact.Fax = "zzz";
            addcontact.Email = "zzz";
            addcontact.Email2 = "zzz";
            addcontact.Email3 = "zzz";
            addcontact.Homepage = "zzz";
            addcontact.Bday = "12";
            addcontact.Bmonth = "December";
            addcontact.Byear = "1991";
            addcontact.Aday = "12";
            addcontact.Amonth = "December";
            addcontact.Ayear = "2021";
            addcontact.Address2 = "zzz";
            addcontact.Phone2 = "zzz";
            addcontact.Notes = "zzz";

            GroupData addgroup = new GroupData("New Group 1");
            addgroup.Header = "aaa1";
            addgroup.Footer = "bbb1";

            appmanager.Contacts.CreateContactIfAbsent(addcontact);
            appmanager.Nav.GoToGroupsPage();
            appmanager.Groups.CreateGroupIfAbsent(addgroup);          

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            

            appmanager.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);




            
        }
    }
}
