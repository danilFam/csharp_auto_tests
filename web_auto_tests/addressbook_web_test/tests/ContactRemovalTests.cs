using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemove()
        {

            const int contactToRemoveIndex = 1;
            var contact = new ContactBuilder().Build();

            List<ContactFormData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(contactToRemoveIndex, contact);

            List<ContactFormData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
