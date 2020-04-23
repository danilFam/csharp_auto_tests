using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_test
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]

        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactFormData> fromUI = app.Contacts.GetContactList();
                List<ContactFormData> fromDB = ContactFormData.GetAllContacts();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromDB, fromUI);
            }
        }
    }
}
