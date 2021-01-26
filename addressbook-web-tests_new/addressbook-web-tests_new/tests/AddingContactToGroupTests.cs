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

            GroupData group1 = GroupData.GetAll()[0];


            
            List<ContactData> contactsFromGroup1 = group1.GetContacts();
            ContactData contactNotInGroup1 = ContactData.GetAll().Except(contactsFromGroup1).FirstOrDefault();
            ContactData firstContactFromAllContacts = ContactData.GetAll().FirstOrDefault();            

            bool isThisContactInGrop1Exist = contactsFromGroup1.Contains(firstContactFromAllContacts);
            if (isThisContactInGrop1Exist == true)
            {
                appmanager.Contacts.Create(addcontact);
                System.Threading.Thread.Sleep(1000);
                var allContacts  = ContactData.GetAll();

                var contactFromGroupIdList = contactsFromGroup1.Select(x => x.Id);
                foreach (ContactData contact in allContacts)
                {                                      

                    if (!contactFromGroupIdList.Contains(contact.Id))
                    {
                        contactNotInGroup1 = contact;
                        break;
                    }
                }
            }
            else
            { 
            
            }
            appmanager.Contacts.AddContactToGroup(contactNotInGroup1, group1);

            List<ContactData> newList = group1.GetContacts();
            contactsFromGroup1.Add(contactNotInGroup1);
            newList.Sort();
            contactsFromGroup1.Sort();
            Assert.AreEqual(contactsFromGroup1, newList);            
        }
    }
}
