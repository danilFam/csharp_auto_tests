using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class NewGroupTest : TestBase
    {

        [Test]
        public void NewGroup()
        {
            GroupFormData group = new GroupFormData("new test");
            group.Footer = "asd";
            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}