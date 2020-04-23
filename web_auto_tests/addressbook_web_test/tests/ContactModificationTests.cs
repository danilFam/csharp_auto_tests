using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]

        public void ContactModification()
        {
            var newData = new ContactBuilder().Build();
            const int contactToModifyIndex = 1;

            List<ContactFormData> oldContacts = ContactFormData.GetAllContacts();
            ContactFormData oldData = oldContacts[0];

            app.Contacts.Modify(newData, oldData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Firstname = newData.Firstname;
            List<ContactFormData> newContacts = ContactFormData.GetAllContacts();

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactFormData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
    }
}
