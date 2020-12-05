using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper grouphelper;
        protected ContactsHelper contactsHelper;
        private static ThreadLocal<ApplicationManager> appmanager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            grouphelper = new GroupHelper(this);
            contactsHelper = new ContactsHelper(this);

        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! appmanager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Nav.OpenHomePage();
                appmanager.Value = newInstance;

            }
            return appmanager.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        
        public LoginHelper Auth
        {
            get 
            {
                return loginHelper;
            }
        }
        public NavigationHelper Nav
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return grouphelper;
            }
        }
        public ContactsHelper Contacts
        {
            get
            {
                return contactsHelper;
            }
        }        
    }
}
