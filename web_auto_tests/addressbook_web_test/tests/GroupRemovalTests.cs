using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemove()
        {
            const int groupToRemoveIndex = 1;

            List<GroupFormData> oldGroups = GroupFormData.GetAllGroups();
            GroupFormData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupFormData> newGroups = GroupFormData.GetAllGroups();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupFormData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
