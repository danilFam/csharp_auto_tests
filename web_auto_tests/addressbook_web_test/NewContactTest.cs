using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class NewContactTest : TestBase
    {
        
        [Test]
        public void NewContact()
        {
            OpenHomePage();
            Login("admin", "secret");
            InitAddNewContact();
            ContactFormData contact = new ContactFormData("another new contact");
            contact.Lastname = "vasya";
            contact.Address = "bulvar";
            contact.Email = "asd@qwezq.com";
            contact.Company = "best company";
            contact.Address2 = "house";
            FillContactForm(contact);
            SubmitContactForm();
            ReturnToHomePage();
            Logout();
        }
    }
}