﻿
using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void NewContact()
        {
            var contact = new ContactBuilder().Build();

            app.Contacts.Create(contact);
        }
    }
}