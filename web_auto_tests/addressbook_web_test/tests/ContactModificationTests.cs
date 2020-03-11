﻿using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModification()
        {
            var newData = new ContactBuilder().Build();

            const int contactToModifyIndex = 1;

            app.Contacts.Modify(newData, contactToModifyIndex);
        }
    }
}