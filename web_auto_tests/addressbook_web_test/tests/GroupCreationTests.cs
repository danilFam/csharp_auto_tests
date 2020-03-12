using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void NewGroup()
        {
            var group = new GroupBuilder().Build();
            app.Groups.Create(group);
        }
    }
}