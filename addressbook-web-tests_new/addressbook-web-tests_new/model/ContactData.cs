using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

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
            return "Fullname=" + (Firstname + " " + Lastname);
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
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
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
    }    
}

