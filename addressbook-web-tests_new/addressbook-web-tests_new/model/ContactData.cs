using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table (Name = "addressbook")]
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

        [Column (Name = "firstname")]
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
                    string FirstName = x(Firstname);
                    string MiddleName = x(Middlename);
                    string LastName = x(Lastname);
                    string NickName = x(Nickname);
                    string AddreSS = x(Address);
                    string Home1 = x(Home);
                    string Mobile1 = x(Mobile);
                    string Work1 = x(Work);
                    string Fax1 = x(Fax);
                    string HomePage = x(Homepage);
                    string BDAY = x(Bday);
                    string BMONTH = x(Bmonth);
                    string BYEAR = x(Byear);
                    string ADAY = x(Aday);
                    string AMONTH = x(Amonth);
                    string AYEAR = x(Ayear);
                    string AddreSS2 = x(Address2);
                    string PHONE2 = x(Phone2);
                    
                    return   (CleanUp2(FirstName) + CleanUp2(MiddleName) + CleanUp2(LastName) + CleanUp2(NickName)
                        + CleanUp2(Title) + CleanUp2(Company)
                        + CleanUp2(AddreSS) + CleanUp2(Home1) + CleanUp2(Mobile1) + CleanUp2(Work1) + CleanUp2(Fax1)
                        + CleanUp2(Email) + CleanUp2(Email2) + CleanUp2(Email3) + CleanUp2(HomePage)
                        + CleanUp2(BDAY) + CleanUp2(BMONTH) + CleanUp2(BYEAR)
                        + CleanUp2(ADAY) + CleanUp2(AMONTH) + CleanUp2(AYEAR)
                        + CleanUp2(AddreSS2) + CleanUp2(PHONE2) + CleanUp2(Notes)).Trim(); 
                                                            
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string x(string input)
        {
            if (input == "" || input == null || input == "0") 
            {
                return ""; 
            }
            else
            {
                return input;
            }            
        }

        public string CleanUp2(string alldetails)
        {
            if (alldetails == null || alldetails == "")
            {
                return "";
            }
            return alldetails.Replace("https://", "").Replace(" ","").Replace(" ", "")
                  .Replace("-", "").Replace("(", "").Replace(")", "").Replace(".", "");
        }


        public string CleanUp(string emailandphone)
        {
            if (emailandphone == null || emailandphone =="")
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
    }    

}

