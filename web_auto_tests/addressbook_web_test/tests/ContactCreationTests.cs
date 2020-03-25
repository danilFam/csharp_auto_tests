using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void NewContact()
        {

            List<ContactFormData> oldContacts = app.Contacts.GetContactList();

            var newContact = new ContactBuilder().Build();

            app.Contacts.Create(newContact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactFormData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}