using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; 
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactsHelper : HelperBase
    {
        private bool acceptNextAlert = true;
        private ContactData _contactData = null;
        private GroupData _groupData = null;
        private List<ContactData> _contactsFromGroup = null;
        private List<ContactData> _newlist = null;        
        public ContactData GetContactInformationFromDetails_deprecated(int index)
        {
            manager.Nav.OpenHomePage();
            CheckDetails(0);
            IWebElement details = driver.FindElement(By.XPath("//div[@id='content']"));
            string alldetails = details.Text;

            string[] allDetailsArray = alldetails.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            string fullname = allDetailsArray[0];
            string[] fullNameArray = fullname.Split(' ');
            string firstName = fullNameArray[0];
            string middleName = fullNameArray[1];
            string lastName = allDetailsArray[0].Split(' ').Last();


            string nickName = allDetailsArray[1];
            string company = allDetailsArray[3];
            string title = allDetailsArray[2];
            string address = allDetailsArray[4];
            string homePhone = allDetailsArray[5].Split(' ').Last();
            string mobilePhone = allDetailsArray[6].Split(' ').Last();
            string workPhone = allDetailsArray[7].Split(' ').Last();
            string fax = allDetailsArray[8].Split(' ').Last();
            string email = allDetailsArray[9];
            string email2 = allDetailsArray[10];
            string email3 = allDetailsArray[11];
            string homePage = allDetailsArray[13].Insert(0, "https://");

            string[] birthDateArray = allDetailsArray[14].Split(' ');
            string[] birthDayMonthArray = birthDateArray[1].Split('.');

            string bDay = birthDayMonthArray[0];

            string bMonth = birthDateArray[2];
            string bYear = birthDateArray[3];

            string[] anniversaryDateArray = allDetailsArray[15].Split(' ');

            string aDay = anniversaryDateArray[1].Replace(".", "");
            string aMonth = anniversaryDateArray[2];
            string aYear = anniversaryDateArray[3];

            string address2 = allDetailsArray[16];
            string phone2 = allDetailsArray[17].Split(' ').Last();
            string notes = allDetailsArray[18];

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homePage,
                Bday = bDay,
                Bmonth = bMonth,
                Byear = bYear,
                Aday = aDay,
                Amonth = aMonth,
                Ayear = aYear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }        

        public void TestRemovingContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Nav.OpenHomePage();
            SelectGroupToRemove(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Nav.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectGroupToRemove(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void SelectContact(string Id)
        {
            driver.FindElement(By.Id(Id)).Click();
        }


        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public string GetContactInformationFromDetails(int v)
        {
            manager.Nav.OpenHomePage();
            CheckDetails(v);
            IWebElement details = driver.FindElement(By.XPath("//div[@id='content']"));
            string toModify = details.Text;
            return toModify;
        }

        public ContactData GetContactInformationFromFullEditForm(int v)
        {
            manager.Nav.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homePage,
                Bday = bDay,
                Bmonth = bMonth,
                Byear = bYear,
                Aday = aDay,
                Amonth = aMonth,
                Ayear = aYear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Nav.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Nav.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Phone2 = phone2,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };

        }

        public ContactsHelper(ApplicationManager manager) : base(manager)
        {
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Nav.OpenHomePage();
                IList<IWebElement> elements = driver.FindElements(By.Name("entry"));


                for (int i = 0; i < elements.Count(); i++)
                {
                    contactCache.Add(GetContactInformationFromTable(i));
                }
            }
            //todo: investigate is it necessary to use new List<ContactData>(contactCache) again ?
            return new List<ContactData>(contactCache);
        }

        public ContactsHelper Modify(int v, ContactData newData)
        {
            manager.Nav.OpenHomePage();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            return this;

        }

        public ContactsHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Nav.OpenHomePage();
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            return this;

        }

        public ContactsHelper Remove(int v, ContactData contact)
        {
            manager.Nav.OpenHomePage();
            SelectContact(v, contact);
            RemoveContact();
            CloseModal();
            return this;
        }

        public ContactsHelper Remove(ContactData contact)
        {
            manager.Nav.OpenHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            CloseModal();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        public ContactsHelper CloseModal()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }



        public ContactsHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper SelectContact(int index, ContactData contact)
        {
            if (IsElementPresent(By.XPath("//span[@id='search_count' and starts-with(text(),'0')]")))
            {
                Create(contact);
                manager.Nav.OpenHomePage();
            }
            driver.FindElement(By.XPath("(//td//input)[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactsHelper Create(ContactData contact)
        {
            manager.Nav.GoToContactPage();
            FillContactForm(contact);
            SubmitContactCreation();            
            return this;
        }

        public ContactsHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            //driver.FindElement(By.XPath("//div[@id='content']/form/input[7]")).SendKeys(contact.Image);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            driver.FindElement(By.XPath("//div[@id='content']/form/label[9]")).Click();
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("bmonth")).Click();
            Type(By.Name("byear"), contact.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.Name("aday")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.Name("amonth")).Click();
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }
        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        public ContactsHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactsHelper InitContactModification(String id)
        {
            driver.FindElement(By.CssSelector("a[href='edit.php?id=" + id + "']")).Click();
            return this;
        }

        public ContactsHelper CheckDetails(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactsHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//form//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactsHelper CreateContactIfAbsent(ContactData contact)
        {
            if (IfContactAbsent())
            {
                Create(contact);
                manager.Nav.OpenHomePage();
            }
            return this;
        }
        private bool IfContactAbsent()
        {
            if (IsElementPresent(By.XPath("//span[@id='search_count' and starts-with(text(),'0')]")))
            {
                return true;
            }
            return false;
        }

        public ContactData GetValidContactModel()
        {
            ContactData validContactModel = new ContactData("Test", "Test");
            validContactModel.Middlename = "zzz";
            validContactModel.Nickname = "zzz";
            validContactModel.Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif";
            validContactModel.Title = "zzz";
            validContactModel.Company = "zzz";
            validContactModel.Address = "zzz";
            validContactModel.Home = "zzz";
            validContactModel.Mobile = "zzz";
            validContactModel.Work = "zzz";
            validContactModel.Fax = "zzz";
            validContactModel.Email = "zzz";
            validContactModel.Email2 = "zzz";
            validContactModel.Email3 = "zzz";
            validContactModel.Homepage = "zzz";
            validContactModel.Bday = "12";
            validContactModel.Bmonth = "December";
            validContactModel.Byear = "1991";
            validContactModel.Aday = "12";
            validContactModel.Amonth = "December";
            validContactModel.Ayear = "2021";
            validContactModel.Address2 = "zzz";
            validContactModel.Phone2 = "zzz";
            validContactModel.Notes = "zzz";
            return validContactModel;
        }

        public GroupData GetValidGroupModel()
        {
            GroupData getValidGroupModel = new GroupData("New Group 1");
            getValidGroupModel.Header = "aaa1";
            getValidGroupModel.Footer = "bbb1";
            return getValidGroupModel;
        }

        public void IfGroupOrContactIsAbsentCreateThem()
        {
            manager.Contacts.CreateContactIfAbsent(GetValidContactModel());
            manager.Nav.GoToGroupsPage();
            manager.Groups.CreateGroupIfAbsent(GetValidGroupModel());
        }

        public void IfContactWithoutGroupIsAbsentProvideContactWithoutGroup()
        {
            GroupData group1 = GroupData.GetAll()[0];
            List<ContactData> contactsFromGroup1 = group1.GetContacts();
            _groupData = group1;
            ContactData contactNotInGroup1 = ContactData.GetAll().Except(contactsFromGroup1).FirstOrDefault();
            ContactData firstContactFromAllContacts = ContactData.GetAll().FirstOrDefault();
            _contactData = contactNotInGroup1;
            bool isThisContactInGrop1Exist = contactsFromGroup1.Contains(firstContactFromAllContacts);
            _contactsFromGroup = contactsFromGroup1;
            if (isThisContactInGrop1Exist == true)
            {
                manager.Contacts.Create(GetValidContactModel());                
                var allContacts = ContactData.GetAll();

                var contactFromGroupIdList = contactsFromGroup1.Select(x => x.Id);
                foreach (ContactData contact in allContacts)
                {

                    if (!contactFromGroupIdList.Contains(contact.Id))
                    {
                        contactNotInGroup1 = contact;
                        _contactData = contactNotInGroup1;
                        break;
                    }
                }
            }
        }
        public void IfContactIsAbsentInGroupProvideContactToGroup()
        {
            GroupData group1 = GroupData.GetAll()[0];
            List<ContactData> contactsFromGroup1 = group1.GetContacts();
            _groupData = group1;               
            _contactsFromGroup = contactsFromGroup1;            
            _groupData = group1;
            ContactData firstContactFromGroup = contactsFromGroup1.FirstOrDefault();
            _contactData = firstContactFromGroup;
            bool isThisGroupContainsContacts = contactsFromGroup1.Any();
            _contactsFromGroup = contactsFromGroup1;
            if (isThisGroupContainsContacts == false)
            {
                manager.Nav.OpenHomePage();                
                ContactData contactNotInGroup1 = ContactData.GetAll().Except(contactsFromGroup1).FirstOrDefault();
                manager.Contacts.AddContactToGroup(contactNotInGroup1, _groupData);
                List<ContactData> contactsFromGroup = group1.GetContacts();
                ContactData firstContactFromGroupIf = contactsFromGroup.FirstOrDefault();
                _contactData = firstContactFromGroupIf;                
            }            
        }        

        public void PrepareActualAndExpectedContactsListsToComparison()
        {
            List<ContactData> newList = _groupData.GetContacts();
            _contactsFromGroup.Add(_contactData);
            newList.Sort();
            _contactsFromGroup.Sort();
            _newlist = newList;
        }

        public void PrepareActualAndExpectedContactsListsToComparisonAfterDelete()
        {            
            List<ContactData> newList = _groupData.GetContacts();
            _contactsFromGroup.Remove(_contactData);
            newList.Sort();
            _contactsFromGroup.Sort();
            _newlist = newList;
        }

        public ContactData GetCurrentContactData()
        {
            return _contactData;
        }

        public GroupData GetCurrentGroupData()
        {
            return _groupData;
        }

        public IEnumerable<ContactData> GetContactsFromGroup()
        {
            return _contactsFromGroup;
        }

        public IEnumerable<ContactData> GetListForComparison()
        {
            return _newlist;
        }
    }
}