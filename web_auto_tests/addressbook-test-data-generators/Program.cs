using System;
using System.IO;

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
                ContactDataFilesCreator.CreateContactFiles(count, writer, format);
            }
            else if (type == "groups")
            {
                GroupDataFilesCreator.CreateGroupFiles(count, writer, format);
            }
        }
    }
}
