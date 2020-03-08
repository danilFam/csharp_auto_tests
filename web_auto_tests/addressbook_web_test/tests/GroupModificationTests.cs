using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]

        public void GroupModication()
        {
            GroupFormData newData = new GroupFormData("modified gr");
            newData.Footer = "modify";
            newData.Header = "modify";

            const int groupToModifyIndex = 1;
            app.Groups.Modify(newData, groupToModifyIndex);
        }
    }
}
