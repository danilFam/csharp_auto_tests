using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void NewContact()
        {
            var contact = new ContactBuilder().Build();

            app.Contacts.Create(contact);
        }
    }
}