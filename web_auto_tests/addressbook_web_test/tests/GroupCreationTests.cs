using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void NewGroup()
        {
            GroupFormData group = new GroupFormData("new test");
            group.Footer = "asd";
            app.Groups.Create(group);
        }
    }
}