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
        private string email;
        private string email2;
        private string email3;
        private string address2;
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private string title;
        private string company;
        private string address;
        private string notes;

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
        public string Id { get; set; }
        public string FirstName
        {
            get
            {
                if (firstName == null || firstName == "")
                {
                    return firstName;
                }
                else
                {
                    return firstName + " ";
                }
            }
            set
            {
                firstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                if (middleName == null || middleName == "")
                {
                    return middleName;
                }
                else
                {
                    return middleName + " ";
                }
            }
            set
            {
                middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                if (lastName == null || lastName == "")
                {
                    return lastName;
                }
                else
                {
                    return lastName;
                }
            }
            set
            {
                lastName = value;
            }
        }
        public string NickName
        {
            get
            {
                if (nickName == null || nickName == "")
                {
                    return nickName;
                }
                else
                {
                    return "\r\n" + nickName;
                }
            }
            set
            {
                nickName = value;
            }
        }
        public string Title
        {
            get
            {
                if (title == null || title == "")
                {
                    return title;
                }
                else
                {
                    return "\r\n" + title;
                }
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
                if (company == null || company == "")
                {
                    return company;
                }
                else
                {
                    return "\r\n" + company;
                }
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
                if (address == null || address == "")
                {
                    return address;
                }
                else
                {
                    return "\r\n" + address;
                }
            }
            set
            {
                address = value;
            }
        }
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
                    return "\r\n" + "H: " + homePhone;
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
                    return "\r\n" + "M: " + mobilePhone;
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
                    return "\r\n" + "W: " + workPhone;
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
                    return "\r\n" + "F: " + fax;
                }
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                if (email == null || email == "")
                {
                    return email;
                }
                else
                {
                    return "\r\n" + email;
                }
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
                if (email2 == null || email2 == "")
                {
                    return email2;
                }
                else
                {
                    return "\r\n" + email2;
                }
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
                if (email3 == null || email3 == "")
                {
                    return email3;
                }
                else
                {
                    return "\r\n" + email3;
                }
            }
            set
            {
                email3 = value;
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
                    return "\r\n" + "Homepage:\r\n" + homePage;
                }
            }
            set
            {
                homePage = value;
            }
        }
        public string Address2
        {
            get
            {
                if (address2 == null || address2 == "")
                {
                    return address2;
                }
                else
                {
                    return "\r\n" + address2;
                }
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
                if (phone2 == null || phone2 == "")
                {
                    return phone2;
                }
                else
                {
                    return "\r\n" + "P: " + phone2;
                }
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
                if (notes == null || notes == "")
                {
                    return notes;
                }
                else
                {
                    return "\r\n" + notes;
                }
            }
            set
            {
                notes = value;
            }
        }
        public string AllInformation
        {
            get
            {
                    return (FirstName + MiddleName + LastName
                    + NickName + Title+ Company + Address + "\r\n"
                    + HomePhone + MobilePhone + WorkPhone + Fax + "\r\n"
                    + Email + Email2 + Email3 + HomePage + "\r\n\r\n"
                    + Address2 + "\r\n"
                    + Phone2 + "\r\n"
                    + Notes).Trim();
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
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
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
            return email;
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
            return Regex.Replace(phone, "[ PHMW:()-]", ""); //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
