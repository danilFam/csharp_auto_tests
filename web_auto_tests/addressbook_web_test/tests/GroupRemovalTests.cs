using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemove()
        {
            app.Groups.Remove();
            app.Auth.Logout();
        }

    }
}
