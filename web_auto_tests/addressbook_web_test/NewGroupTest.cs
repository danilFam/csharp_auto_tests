using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class NewGroupTest : TestBase
    {


        [Test]
        public void NewGroup()
        {
            OpenHomePage();
            Login("admin", "secret");
            GoToGroupsPage();
            InitGroupCreation();
            GroupFormData group = new GroupFormData("new");
            group.Footer = "123";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}