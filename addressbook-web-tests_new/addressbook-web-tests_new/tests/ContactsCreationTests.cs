using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
                {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))                
                {
                    
                Middlename = GenerateRandomString(10),
                Nickname = GenerateRandomString(10),
                //Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif",
                Title = GenerateRandomString(10),
                Company = GenerateRandomString(10),
                Address = GenerateRandomString(10),
                Home = GenerateRandomString(10),
                Mobile = GenerateRandomString(10),
                Work = GenerateRandomString(10),
                Fax = GenerateRandomString(10),
                Email = GenerateRandomString(10),
                Email2 = GenerateRandomString(10),
                Email3 = GenerateRandomString(10),
                Homepage = GenerateRandomString(10),
                Bday = GenerateRandomDate(),
                Bmonth = GenerateRandomMonth(),
                Byear = GenerateRandomYear(),
                Aday = GenerateRandomDate(),
                Amonth = GenerateRandomMonth(),
                Ayear = GenerateRandomYear(),
                Address2 = GenerateRandomString(10),
                Phone2 = GenerateRandomString(10),
                Notes = GenerateRandomString(10)
                  
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactsCreationTest(ContactData contact)
        {                
            List<ContactData> oldContacts = ContactData.GetAll();

            appmanager.Contacts.Create(contact);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }        
    }
}
