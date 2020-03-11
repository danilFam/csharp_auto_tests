using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]

        public void GroupModication()
        {
            var newData = new GroupBuilder().Build();

            const int groupToModifyIndex = 1;
            app.Groups.Modify(newData, groupToModifyIndex);
        }
    }
}
