using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test
{
    class ContactFormData
    {
        string firstname, middlename = "", lastname = "", nickname = "",
            title = "", company = "", address = "", home = "",
            mobile = "", work = "", fax = "", email = "",
            email2 = "", email3 = "", homepage = "", address2 = "",
            phone2 = "", notes = "";

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Home
        {
            get { return home; }
            set { home = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string Work
        {
            get { return work; }
            set { work = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }
        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
        public ContactFormData(string firstname)
        {
            this.firstname = firstname;
        }

    }
}
