using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void NewGroup()
        {
            List<GroupFormData> oldGroups = app.Groups.GetGroupList();

            var group = new GroupBuilder().Build();

            app.Groups.Create(group);

            List<GroupFormData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}