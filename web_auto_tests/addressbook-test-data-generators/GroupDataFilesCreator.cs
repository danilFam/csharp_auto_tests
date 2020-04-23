using System;
using System.Collections.Generic;
using System.IO;
using addressbook_web_test;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class GroupDataFilesCreator
    {
        public static void CreateGroupFiles(int count, StreamWriter writer, string format)
        {
            List<GroupFormData> groups = InitializeGroups(count);
            if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }
        }

        private static List<GroupFormData> InitializeGroups(int count)
        {
            List<GroupFormData> groups = new List<GroupFormData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupFormData()
                {
                    Name = TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(20),
                    Footer = TestBase.GenerateRandomString(20)
                });
            }
            return groups;
        }

        static void WriteGroupsToXmlFile(List<GroupFormData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupFormData>)).Serialize(writer, groups);
        }
        static void WriteGroupsToJsonFile(List<GroupFormData> groups, StreamWriter writer)
        {
            string groupsSerialized = JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented);
            writer.Write(groupsSerialized);
            writer.Close();
        }
    }
}
