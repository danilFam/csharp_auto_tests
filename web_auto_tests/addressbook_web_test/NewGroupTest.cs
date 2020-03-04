using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class NewGroupTest : TestBase
    {

        [Test]
        public void NewGroup()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login("admin", "secret");
            navigationHelper.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupFormData group = new GroupFormData("new test");
            group.Footer = "asd";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            loginHelper.Logout();
        }
    }
}