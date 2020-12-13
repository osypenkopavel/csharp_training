﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string fullname;
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string image = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.fullname = lastname +" "+ firstname;
        }
        public ContactData(string fullname)
        {
            //var name1 = fullname.Split(' ').First();
            //var name2 = fullname.Split(' ').Last();
            //this.firstname = name1;
            //this.lastname = name2;
            this.fullname = fullname;
            
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
            return Fullname == other.Fullname;
        }

        public override int GetHashCode()
        {
            return Fullname.GetHashCode();
        }

        public override string ToString()
        {
            return "Fullname=" + Fullname;
        }

        public string Fullname
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
            }
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Fullname.CompareTo(other.Fullname);
        }
        public string Firstname

        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename

        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname

        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname

        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Image

        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }

        }
        public string Title

        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }

        }
        public string Company

        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }

        }
        public string Address

        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Home

        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }
        public string Mobile

        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Work

        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }
        
        public string Fax

        {
            get
            {
                return fax;
            }
            set
            {
                fax= value;
            }
        }
        public string Email

        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2

        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3

        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage

        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday

        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth

        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear

        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Aday

        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Amonth

        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public string Ayear

        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
        public string Address2

        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Phone2

        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }
        public string Notes

        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

       
    }
    
}

