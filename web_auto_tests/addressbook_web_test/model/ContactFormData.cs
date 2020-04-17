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
                    return (ReplaceNotVisibleInFormSymbols(HomePhone) + ReplaceNotVisibleInFormSymbols(MobilePhone)
                        + ReplaceNotVisibleInFormSymbols(WorkPhone) + ReplaceNotVisibleInFormSymbols(Phone2)).Trim();
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
                    return (AddLineBreakSymbol(Email) + AddLineBreakSymbol(Email2) + AddLineBreakSymbol(Email3)).Trim();
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
                    return ($"{ReplaceSpecialSymbolsWithEmptyString(Firstname)}{ReplaceSpecialSymbolsWithEmptyString(Middlename)}{ReplaceSpecialSymbolsWithEmptyString(Lastname)}{ReplaceSpecialSymbolsWithEmptyString(Nickname)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(Title)}{ReplaceSpecialSymbolsWithEmptyString(Company)}{ReplaceSpecialSymbolsWithEmptyString(Address)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(HomePhone == string.Empty ? HomePhone : "H:" + HomePhone)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(MobilePhone == string.Empty ? MobilePhone : "M:" + MobilePhone)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(WorkPhone == string.Empty ? WorkPhone : "W:" + WorkPhone)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(Fax == string.Empty ? Fax : "F:" + Fax)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(Email)}{ReplaceSpecialSymbolsWithEmptyString(Email2)}{ReplaceSpecialSymbolsWithEmptyString(Email3)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(Homepage == string.Empty ? Homepage : "Homepage:" + Homepage)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(Address2)}{ReplaceSpecialSymbolsWithEmptyString(Phone2 == string.Empty ? Phone2 : "P:" + Phone2)}" +
                        $"{ReplaceSpecialSymbolsWithEmptyString(Notes)}").Trim();
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
        public override string ToString()
        {
            return Firstname;
        }
        private string ReplaceNotVisibleInFormSymbols(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[(). -]", "") + "\r\n";
        }

        private string AddLineBreakSymbol(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
        }
        private string ReplaceSpecialSymbolsWithEmptyString(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, @"[\n\t\r\s]", "");
        }
    }
}
