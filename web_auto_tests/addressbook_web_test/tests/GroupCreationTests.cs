using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

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

        public static IEnumerable<GroupFormData> GroupDataFromXmlFile()
        {
            var path = TestContext.CurrentContext.TestDirectory + @"\groups.xml";
            var serializedGroups = new XmlSerializer(typeof(List<GroupFormData>))
                .Deserialize(new StreamReader(path));
            return (List<GroupFormData>)serializedGroups;
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void NewGroupFromXmlFile(GroupFormData newGroup)
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
        public static IEnumerable<GroupFormData> GroupDataFromJsonFile()
        {
            string path = TestContext.CurrentContext.TestDirectory + @"\groups.json";
            return JsonConvert.DeserializeObject<List<GroupFormData>>(File.ReadAllText(path));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void NewGroupFromJsonFile(GroupFormData newGroup)
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