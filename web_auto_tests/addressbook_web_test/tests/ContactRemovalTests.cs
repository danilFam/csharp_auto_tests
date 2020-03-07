using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemove()
        {
            app.Contacts.Remove();
            app.Auth.Logout();
        }
    }
}
