﻿using System;
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

        public  ContactData GetContactInformationFromEditForm(int index)
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
                IEnumerable<IWebElement> elements1 = driver.FindElements(By.XPath("//*[@id='maintable']//td[2]")).ToList();
                IEnumerable<IWebElement> elements2 = driver.FindElements(By.XPath("//*[@id='maintable']//td[3]"));

                for (int i = 0; i < elements1.Count(); i++)
                {
                    string name = elements1.ElementAt<IWebElement>(i).Text + " " + elements2.ElementAt<IWebElement>(i).Text;
                    contactCache.Add(new ContactData(name));
                }
            }
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

        public ContactsHelper Remove(int v, ContactData contact)
        {
            manager.Nav.OpenHomePage();
            SelectContact(v, contact);
            RemoveContact();
            CloseModal();
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
            driver.FindElement(By.XPath("(//td//input)[" + (index+1) + "]")).Click();
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
            driver.FindElement(By.XPath("//div[@id='content']/form/input[7]")).SendKeys(contact.Image);
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
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();                       
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
            if (IfContactPresent())
            {
                Create(contact);
                manager.Nav.OpenHomePage();
            }
            return this;
        }
        private bool IfContactPresent()
        {
            if (IsElementPresent(By.XPath("//span[@id='search_count' and starts-with(text(),'0')]")))
            {
                return true;
            }
            return false;
        }
    }
}

