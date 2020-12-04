using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {               
        protected ApplicationManager appmanager;

        [SetUp]
        public void SetupApplicationManager()
        {
            appmanager = ApplicationManager.GetInstance();
        }           
    }
}
