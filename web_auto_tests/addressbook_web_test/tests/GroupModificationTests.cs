using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]

        public void GroupModication()
        {
            var newData = new GroupBuilder().Build();
            var group = new GroupBuilder().Build();
            const int groupToModifyIndex = 1;

            app.Groups.Modify(groupToModifyIndex, newData, group);
        }
    }
}
