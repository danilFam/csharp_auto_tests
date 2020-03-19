using NUnit.Framework;
using System.Collections.Generic;

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

            List<GroupFormData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(groupToModifyIndex, newData, group);

            List<GroupFormData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
