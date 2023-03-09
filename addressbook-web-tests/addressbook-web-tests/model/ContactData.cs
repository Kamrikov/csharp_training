using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string mobilePhone;
        private string homePhone;
        private string workPhone;
        private string fax;
        private string homePage;
        private string phone2;

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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
            return LastName == other.LastName
                && FirstName == other.FirstName;
        }
        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FirstName.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + LastName + "\n" + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) != 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            else
            {
                return FirstName.CompareTo(other.FirstName);
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone
        {
            get
            {
                if (homePhone == null || homePhone == "")
                {
                    return homePhone;
                }
                else
                {
                    return "H:" + homePhone;
                }
            }
            set
            {
                homePhone = value;
            }
        }
        public string MobilePhone
        {
            get
            {
                if (mobilePhone == null || mobilePhone == "")
                {
                    return mobilePhone;
                }
                else
                {
                    return "M:" + mobilePhone;
                }
            }
            set
            {
                mobilePhone = value;
            }
        }
        public string WorkPhone
        {
            get
            {
                if (workPhone == null || workPhone == "")
                {
                    return workPhone;
                }
                else
                {
                    return "W:" + workPhone;
                }
            }
            set
            {
                workPhone = value;
            }
        }
        public string Fax
        {
            get
            {
                if (fax == null || fax == "")
                {
                    return fax;
                }
                else
                {
                    return "F:" + fax;
                }
            }
            set
            {
                fax = value;
            }
        }
        public string HomePage
        {
            get
            {
                if (homePage == null || homePage == "")
                {
                    return homePage;
                }
                else
                {
                    return "Homepage:" + homePage;
                }
            }
            set
            {
                homePage = value;
            }
        }
        public string Phone2
        {
            get
            {
                if (phone2 == null || phone2 == "")
                {
                    return phone2;
                }
                else
                {
                    return "P:" + phone2;
                }
            }
            set
            {
                phone2 = value;
            }
        }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address2 { get; set; }
        public string Notes { get; set; }
        public string AllInformation
        {
            get
            {
                return Regex.Replace(FirstName + MiddleName + LastName + NickName + Title + Company + Address + HomePhone + MobilePhone + WorkPhone + Fax
                + Email + Email2 + Email3 + HomePage + Address2 + Phone2 + Notes, "[ ]", "");
            }
            set
            {
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
                    return (CleanUpEmail(Email) + CleanUpPhone(Email2) + CleanUpPhone(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
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
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone) + CleanUpPhone(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ PHMW:()-]", "") + "\r\n"; //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
