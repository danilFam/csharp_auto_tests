using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemove()
        {
            const int contactToRemoveIndex = 1;
            var contact = new ContactBuilder().Build();

            app.Contacts.Remove(contactToRemoveIndex, contact);
        }
    }
}
