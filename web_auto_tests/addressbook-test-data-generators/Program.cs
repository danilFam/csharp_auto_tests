using addressbook_web_test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (type == "contacts")
            {
                List<ContactFormData> contacts = new List<ContactFormData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactFormData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(30),
                        Homepage = TestBase.GenerateRandomString(30),
                        Email = TestBase.GenerateRandomString(20),
                    });
                }
                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
            }
            else if (type == "groups")
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
        static void WriteContactsToXmlFile(List<ContactFormData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactFormData>)).Serialize(writer, contacts);
        }
        static void WriteContactsToJsonFile(List<ContactFormData> contacts, StreamWriter writer)
        {
            string contactsSerialized = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
            writer.Write(contactsSerialized);
            writer.Close();
        }
    }
}
