using System;
using System.Text.RegularExpressions;

namespace addressbook_web_test
{
    public class ContactFormData : IEquatable<ContactFormData>, IComparable<ContactFormData>
    {
        private string allPhones;
        private string allEmails;
        private string allInformation;

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone)
                        + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
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
                    return (LineBreak(Email) + LineBreak(Email2) + LineBreak(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllInformation
        {
            get
            {
                if (allInformation != null)
                {
                    return allInformation;
                }
                else
                {
                    return ($"{Delete(Firstname)}{Delete(Middlename)}{Delete(Lastname)}{Delete(Nickname)}" +
                        $"{Delete(Title)}{Delete(Company)}{Delete(Address)}" +
                        $"{Delete(HomePhone == string.Empty ? HomePhone : "H:" + HomePhone)}" +
                        $"{Delete(MobilePhone == string.Empty ? MobilePhone : "M:" + MobilePhone)}" +
                        $"{Delete(WorkPhone == string.Empty ? WorkPhone : "W:" + WorkPhone)}" +
                        $"{Delete(Fax == string.Empty ? Fax : "F:" + Fax)}" +
                        $"{Delete(Email)}{Delete(Email2)}{Delete(Email3)}" +
                        $"{Delete(Homepage == string.Empty ? Homepage : "Homepage:" + Homepage)}" +
                        $"{Delete(Address2)}{Delete(Phone2 == string.Empty ? Phone2 : "P:" + Phone2)}" +
                        $"{Delete(Notes)}").Trim();
                }
            }
            set
            {
                allInformation = value;
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
            return Regex.Replace(phone, "[(). -]", "") + "\r\n";
        }

        private string LineBreak(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
        }
        private string Delete(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, @"[\n\t\r\s]", "");
        }
    }
}
