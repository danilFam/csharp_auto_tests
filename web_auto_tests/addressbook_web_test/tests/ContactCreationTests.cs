using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void NewContact()
        {
            ContactFormData contact = new ContactFormData("another new contact");
            contact.Lastname = "vasya";
            contact.Address = "bulvar";
            contact.Email = "asd@qwezq.com";
            contact.Company = "best company";
            contact.Address2 = "house";
            app.Contacts.Create(contact);
        }
    }
}