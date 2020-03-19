using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemove()
        {
            var group = new GroupBuilder().Build();
            const int groupToRemoveIndex = 1;

            List<GroupFormData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(groupToRemoveIndex, group);

            List<GroupFormData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
