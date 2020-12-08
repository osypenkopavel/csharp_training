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
        public ContactsHelper(ApplicationManager manager) : base(manager)
        {
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
            return this;
        }

        public ContactsHelper SelectContact(int index, ContactData contact)
        {
            if (IsElementPresent(By.XPath("//span[@id='search_count' and starts-with(text(),'0')]")))
            {
                Create(contact);
                manager.Nav.OpenHomePage();
            }
            driver.FindElement(By.XPath("(//td//input)[" + index + "]")).Click();
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
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();                       
            return this;
        }
        public ContactsHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//form//input[@value='Update']")).Click();
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

