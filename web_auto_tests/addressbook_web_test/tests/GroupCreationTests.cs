using NUnit.Framework;
using System;
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

            var newGroup = new GroupBuilder().Build();

            app.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupFormData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        public static IEnumerable<GroupFormData> RandomGroupDataProvider()
        {
            List<GroupFormData> groups = new List<GroupFormData>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new GroupFormData()
                {
                    Name = GenerateRandomString(10),
                    Header = GenerateRandomString(20),
                    Footer = GenerateRandomString(20)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void NewGroupRandom(GroupFormData newGroup)
        {
            List<GroupFormData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupFormData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}