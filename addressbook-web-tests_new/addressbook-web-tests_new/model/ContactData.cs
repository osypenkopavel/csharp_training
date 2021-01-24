using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Globalization;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;
        public ContactData()
        {

        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname + "\nLastname=" + Lastname + "\nFirstname=" + "\nMiddlename=" + Middlename;

            //+ "\nNickname=" + Nickname + "\nImage=" + Image + "\nTitle=" + Title + "\nCompany=" + Company + "\nAddress=" + Address
            //+ "\nHome=" + Home + "\nMobile=" + Mobile + "\nWork=" + Work + "\nFax=" + Fax + "\nEmail=" + Email + "\nEmail2=" + Email2
            //+ "\nEmail3=" + Email3 + "\nHomepage=" + Homepage + "\nBday=" + Bday + "\nBmonth=" + Bmonth + "\nByear=" + Byear
            //+ "\nAday=" + Aday + "\nAmonth=" + Amonth + "\nAyear=" + Ayear + "\nAddress2=" + Address2 + "\nPhone2=" + Phone2
            //+ "\nNotes=" + Notes; 
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int compare = Lastname.CompareTo(other.Lastname);
            if (compare != 0)
            {
                return compare;
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
        }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        public string Image { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string Home { get; set; }
        [Column(Name = "mobile")]
        public string Mobile { get; set; }
        [Column(Name = "work")]
        public string Work { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        [Column(Name = "aday")]
        public string Aday { get; set; }
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    string FirstName = Cleanup2(Firstname);
                    string MiddleName = Cleanup3(Middlename);
                    string LastName = Cleanup17(Lastname);
                    string NickName = Cleanup4(Nickname);
                    string TITLE = Cleanup4(Title);
                    string COMPANY = Cleanup4(Company);
                    string AddreSS = Cleanup5(Address);
                    string Home1 = Cleanup6(Home);
                    string Mobile1 = Cleanup7(Mobile);
                    string Work1 = Cleanup8(Work);
                    string Fax1 = Cleanup9(Fax);
                    string EMAIL1 = Cleanup4(Email);
                    string EMAIL2 = Cleanup4(Email2);
                    string EMAIL3 = Cleanup4(Email3);
                    string HomePage = Cleanup10(Homepage);
                    string BDAY = Cleanup11(Bday);
                    string BMONTH = Cleanup2(Bmonth);
                    string BYEAR = Cleanup14(Byear);
                    string ADAY = Cleanup12(Aday);
                    string AMONTH = Cleanup2(Amonth);
                    string AYEAR = Cleanup15(Ayear);
                    string AddreSS2 = Cleanup5(Address2);
                    string PHONE2 = Cleanup13(Phone2);
                    string NOTES = Cleanup16(Notes);                          
                                        

                    return ((FirstName) + (MiddleName) + (LastName) + (NickName)
                        + (TITLE) + (COMPANY) + (AddreSS) + (Home1) + (Mobile1)
                        + (Work1) + (Fax1) + (EMAIL1) + (EMAIL2) + (EMAIL3) + (HomePage)
                        + (BDAY) + (BMONTH) + (BYEAR) + (ADAY) + (AMONTH) + (AYEAR)
                        + (AddreSS2) + (PHONE2) + (NOTES)).Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }


        string total = string.Empty;
        string Atotal = string.Empty;

        private string Cleanup2(string input)
        {
            if (input == "" || input == null || input == "0" || input == "-")
            {
                return "";
            }
            return input + " ";
        }

        private string Cleanup3(string input)
        {
            if (input == "" || input == null || input == "-")
            {
                return "";
            }
            return input + " ";
        }

        private string Cleanup4(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return input + "\r\n";
        }       

        private string Cleanup5(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return input + "\r\n\r\n";
        }

        private string Cleanup6(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return "H: " + input + "\r\n";
        }

        private string Cleanup7(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return "M: " + input + "\r\n";
        }

        private string Cleanup8(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return "W: " + input + "\r\n";
        }

        private string Cleanup9(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return "F: " + input + "\r\n\r\n";
        }

        private string Cleanup10(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return "Homepage:" + "\r\n" + input + "\r\n";
        }

        private string Cleanup11(string input)
        {
            if (input == "" || input == null || input == "- " || input == "0")
            {
                return "Birthday" + " ";
            }
            return "\r\n" + "Birthday" + " " + input + ". ";
        }

        private string Cleanup12(string input)
        {
            if (input == "" || input == null || input == "- " || input == "0")
            {
                return "Anniversary" + " ";
            }
            return "Anniversary" + " " + input + ". ";
        }
        private string Cleanup13(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return "P: " + input;
        }
        private string Cleanup14(string input)
        {

            if (input == "" || input == null || input == "- " || input == "0")
            {
                return "";
            }
            if ((Bday == "" || Bday.Contains("-")) || (Bmonth == "" || Bmonth.Contains("-")))
            {
                total = (DateTime.Now.Year - Convert.ToInt32(Byear)).ToString();
                return input + " (" + total + ")" + "\r\n";
            }
            if (DateTime.Now < ReturnDate(Bday, ParseMonth(Bmonth)))
            {
                total = (DateTime.Now.Year - Convert.ToInt32(Byear) - 1).ToString();
            }
            else
            {
                total = (DateTime.Now.Year - Convert.ToInt32(Byear)).ToString();
            }            
            return input + " (" + total + ")" + "\r\n";
        }
        private string Cleanup15(string input)
        {

            if (input == "" || input == null || input == "- ")
            {
                return "";
            }
            if ((Aday == "" || Aday.Contains("-")) || (Amonth == "" || Amonth.Contains("-")))
            {
                Atotal = (DateTime.Now.Year - Convert.ToInt32(Ayear)).ToString();
                return input + " (" + Atotal + ")" + "\r\n";
            }

            if (DateTime.Now < ReturnDate(Aday, ParseMonth(Amonth)))
            {
                Atotal = (DateTime.Now.Year - Convert.ToInt32(Ayear) - 1).ToString();
            }
            else
            {
                Atotal = (DateTime.Now.Year - Convert.ToInt32(Ayear)).ToString();
            }
            
            return input + " (" + Atotal + ")" + "\r\n\r\n";
        }
        private string Cleanup16(string input)
        {
            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return input;
        }
        private string Cleanup17(string input)
        {
            if (input == "" && Firstname != "")
            {
                return input +"\r\n";
            }    

            if (input == "" || input == null || input == "0")
            {
                return "";
            }
            return input + "\r\n";
        }

        public string CleanUp(string emailandphone)
        {
            if (emailandphone == null || emailandphone == "")
            {
                return "";
            }
            return emailandphone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
        public int ParseMonth(string month)
        {
            switch (month)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;

                default:
                    throw new InvalidOperationException();
            }            
        }
        public DateTime ReturnDate(string day, int month)
        {            
            var Text = $"{day}/{month}/{DateTime.Now.Year}";
            DateTime date = DateTime.ParseExact(Text, "d/M/yyyy", CultureInfo.CurrentCulture);
            return date;            
        }
    }
}

