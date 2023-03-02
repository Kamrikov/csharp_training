using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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
            return "name=" + LastName + " " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(other, LastName))
            {
                return LastName.CompareTo(other.LastName);
            }
            else
            {
                return FirstName.CompareTo(other.FirstName);
            }
            

            // return LastName.CompareTo(other.LastName) + FirstName.CompareTo(other.FirstName);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
