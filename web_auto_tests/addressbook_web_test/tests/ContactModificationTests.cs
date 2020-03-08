using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
   public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModification()
        {
            ContactFormData newData = new ContactFormData("modify");
            newData.Lastname = "modify";
            newData.Address = "modify";
            newData.Email = "modify@test.com";
            newData.Company = "modify";
            newData.Address2 = "modify";
            const int contactToModifyIndex = 1;

            app.Contacts.Modify(newData, contactToModifyIndex);
        }
    }
}
