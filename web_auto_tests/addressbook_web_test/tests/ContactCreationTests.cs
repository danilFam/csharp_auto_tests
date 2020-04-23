using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ContactCreationTests : ContactTestBase
    {

        [Test]
        public void NewContact()
        {

            List<ContactFormData> oldContacts = ContactFormData.GetAllContacts();

            var newContact = new ContactBuilder().Build();

            app.Contacts.Create(newContact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactFormData> newContacts = ContactFormData.GetAllContacts();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        public static IEnumerable<ContactFormData> ContactDataFromXmlFile()
        {
            string path = TestContext.CurrentContext.TestDirectory + @"..\..\..\..\addressbook-test-data-generators\bin\Debug" + @"\contacts.xml";
            var serializedContacts = new XmlSerializer(typeof(List<ContactFormData>))
                .Deserialize(new StreamReader(path));
            return (List<ContactFormData>)serializedContacts;
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void NewContactFromXmlFile(ContactFormData newContact)
        {
            List<ContactFormData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(newContact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactFormData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        public static IEnumerable<ContactFormData> ContactDataFromJsonFile()
        {
            string path = TestContext.CurrentContext.TestDirectory + @"\contacts.json";
            return JsonConvert.DeserializeObject<List<ContactFormData>>(File.ReadAllText(path));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void NewContactFromJsonFile(ContactFormData newContact)
        {
            List<ContactFormData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(newContact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactFormData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactFormData> fromUi = app.Contacts.GetContactList();
            DateTime finish = DateTime.Now;
            System.Console.Out.WriteLine(finish.Subtract(start));

            start = DateTime.Now;
            List<ContactFormData> fromDB = ContactFormData.GetAllContacts();
            finish = DateTime.Now;
            System.Console.Out.WriteLine(finish.Subtract(start));
        }
    }
}