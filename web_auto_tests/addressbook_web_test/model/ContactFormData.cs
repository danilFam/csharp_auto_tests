using System;

namespace addressbook_web_test
{
    public class ContactFormData : IEquatable<ContactFormData>, IComparable<ContactFormData>
    {
        private string allPhones;
        private string allEmails;

        public string Firstname { get; set; }
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; }
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; } = "";
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; }
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; } = "";
        public string Notes { get; set; } = "";
        public string Id { get; set; }
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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
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
                    return Email + "\r\n" + Email2 + "\r\n" + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }

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
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "")
                .Replace("(", "").Replace(")", "").Replace(".", "") + "\r\n";
        }
    }
}
