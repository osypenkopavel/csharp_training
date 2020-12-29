using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            if (type=="group")
            { 
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });                 
            }

                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]);
                    if (format == "csv")
                    {
                        WriteGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }       
            else if (type =="contacts")                
                {
                    int count = Convert.ToInt32(args[1]);
                    string filename = args[2];
                    string format = args[3];
                    List<ContactData> contacts = new List<ContactData>();
                    for (int i = 0; i < count; i++)
                    {
                        contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                        {
                            Middlename = TestBase.GenerateRandomString(10),
                            Nickname = TestBase.GenerateRandomString(10),
                            //Image = "D:\\Images\\AVATAR\\86158621245c20cecb12fb.gif",
                            Title = TestBase.GenerateRandomString(10),
                            Company = TestBase.GenerateRandomString(10),
                            Address = TestBase.GenerateRandomString(10),
                            Home = TestBase.GenerateRandomString(10),
                            Mobile = TestBase.GenerateRandomString(10),
                            Work = TestBase.GenerateRandomString(10),
                            Fax = TestBase.GenerateRandomString(10),
                            Email = TestBase.GenerateRandomString(10),
                            Email2 = TestBase.GenerateRandomString(10),
                            Email3 = TestBase.GenerateRandomString(10),
                            Homepage = TestBase.GenerateRandomString(10),
                            Bday = TestBase.GenerateRandomDate(),
                            Bmonth = TestBase.GenerateRandomMonth(),
                            Byear = TestBase.GenerateRandomYear(),
                            Aday = TestBase.GenerateRandomDate(),
                            Amonth = TestBase.GenerateRandomMonth(),
                            Ayear = TestBase.GenerateRandomYear(),
                            Address2 = TestBase.GenerateRandomString(10),
                            Phone2 = TestBase.GenerateRandomString(10),
                            Notes = TestBase.GenerateRandomString(10)
                        });
                    }

                    if (format == "excel")
                    {
                        WriteContactsToExcelFile(contacts, filename);
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(args[2]);
                        if (format == "csv")
                        {
                            WriteContactsToCsvFile(contacts, writer);
                        }
                        else if (format == "xml")
                        {
                            WriteContactsToXmlFile(contacts, writer);
                        }
                        else if (format == "json")
                        {
                            WriteContactsToJsonFile(contacts, writer);
                        }
                        else
                        {
                            System.Console.Out.Write("Unrecognized format" + format);
                        }
                        writer.Close();
                    }
                }
        }

        private static void WriteContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            throw new NotImplementedException();
        }

        private static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            throw new NotImplementedException();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }
    }
}
