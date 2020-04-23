using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemove()
        {
            const int contactToRemoveIndex = 1;

            List<ContactFormData> oldContacts = ContactFormData.GetAllContacts();
            ContactFormData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactFormData> newContacts = ContactFormData.GetAllContacts();
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
