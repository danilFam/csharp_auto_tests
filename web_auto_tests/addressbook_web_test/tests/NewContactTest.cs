using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class NewContactTest : TestBase
    {
        
        [Test]
        public void NewContact()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login("admin", "secret");
            app.Contacts.InitAddNewContact();
            ContactFormData contact = new ContactFormData("another new contact");
            contact.Lastname = "vasya";
            contact.Address = "bulvar";
            contact.Email = "asd@qwezq.com";
            contact.Company = "best company";
            contact.Address2 = "house";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactForm();
            app.Contacts.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}