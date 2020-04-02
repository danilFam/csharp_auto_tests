using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]

    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactFormData fromTable = app.Contacts.GetContactInformationFromTable(1);
            ContactFormData fromForm = app.Contacts.GetContactInformationFromEditForm(1);

            //Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    }
}
