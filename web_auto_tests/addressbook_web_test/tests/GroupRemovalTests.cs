using NUnit.Framework;


namespace addressbook_web_test
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemove()
        {
            var group = new GroupBuilder().Build();
            const int groupToRemoveIndex = 1;
            app.Groups.Remove(groupToRemoveIndex, group);
        }

    }
}
