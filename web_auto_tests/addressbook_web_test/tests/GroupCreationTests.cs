﻿using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GroupCreationTests : GroupTestBase
    {

        [Test]
        public void NewGroup()
        {
            List<GroupFormData> oldGroups = GroupFormData.GetAllGroups();

            var newGroup = new GroupBuilder().Build();

            app.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupFormData> newGroups = GroupFormData.GetAllGroups();
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
            var path = TestContext.CurrentContext.TestDirectory + @"..\..\..\..\addressbook-test-data-generators\bin\Debug" + @"\groups.xml";
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
            string path = TestContext.CurrentContext.TestDirectory + @"..\..\..\..\addressbook-test-data-generators\bin\Debug" + @"\groups.json";
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
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupFormData> fromUi = app.Groups.GetGroupList();
            DateTime finish = DateTime.Now;
            System.Console.Out.WriteLine(finish.Subtract(start));

            start = DateTime.Now;
            List<GroupFormData> fromDB = GroupFormData.GetAllGroups();
            finish = DateTime.Now;
            System.Console.Out.WriteLine(finish.Subtract(start));
        }
    }
}