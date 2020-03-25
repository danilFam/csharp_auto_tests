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
            var newContact = new ContactBuilder().Build();

            List<ContactFormData> oldContacts = app.Contacts.GetContactList();
            ContactFormData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(contactToRemoveIndex, newContact);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactFormData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactFormData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
