using System;

namespace addressbook_web_test
{
    public class ContactFormData : IEquatable<ContactFormData>, IComparable<ContactFormData>
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; }
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; } = "";
        public string Mobile { get; set; }
        public string Work { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; }
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; } = "";
        public string Notes { get; set; } = "";
        public string Id { get; set; }

        public int CompareTo(ContactFormData other)
        {
            if (other is null)
            {
                return 1;
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public bool Equals(ContactFormData other)
        {
            if (other is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }
    }
}
