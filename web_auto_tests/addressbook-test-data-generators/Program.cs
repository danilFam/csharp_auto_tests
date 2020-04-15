using addressbook_web_test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

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
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }
        }

        static void WriteGroupsToXmlFile(List<GroupFormData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupFormData>)).Serialize(writer, groups);
        }
    }
}
