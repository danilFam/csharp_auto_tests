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

            var contact = new ContactBuilder().Build();

            app.Contacts.Create(contact);

            List<ContactFormData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}