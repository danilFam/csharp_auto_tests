using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace addressbook_web_test
{
    class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupFormData> Groups => GetTable<GroupFormData>();
        public ITable<ContactFormData> Contacts => GetTable<ContactFormData>();

    }
}
