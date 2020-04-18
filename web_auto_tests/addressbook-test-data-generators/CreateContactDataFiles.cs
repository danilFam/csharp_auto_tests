using System;
using System.Collections.Generic;
using System.IO;
using addressbook_web_test;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class CreateContactDataFiles
    {
        public static void CreateContactFiles(int count, StreamWriter writer, string format)
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
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }
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
