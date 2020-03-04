using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class NewContactTest : TestBase
    {
        
        [Test]
        public void NewContact()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login("admin", "secret");
            contactHelper.InitAddNewContact();
            ContactFormData contact = new ContactFormData("another new contact");
            contact.Lastname = "vasya";
            contact.Address = "bulvar";
            contact.Email = "asd@qwezq.com";
            contact.Company = "best company";
            contact.Address2 = "house";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactForm();
            contactHelper.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}