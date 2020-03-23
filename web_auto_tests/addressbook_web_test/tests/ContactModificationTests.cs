using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModification()
        {
            var newData = new ContactBuilder().Build();
            var contact = new ContactBuilder().Build();
            const int contactToModifyIndex = 1;

            List<ContactFormData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData, contactToModifyIndex, contact);
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Firstname = newData.Firstname;
            List<ContactFormData> newContacts = app.Contacts.GetContactList();

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
