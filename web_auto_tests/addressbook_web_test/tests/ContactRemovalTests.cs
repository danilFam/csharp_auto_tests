using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemove()
        {
            const int contactToRemoveIndex = 1;
            app.Contacts.Remove(contactToRemoveIndex);
        }
    }
}
