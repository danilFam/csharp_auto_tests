using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class NewGroupTest : TestBase
    {

        [Test]
        public void NewGroup()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login("admin", "secret");
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupFormData group = new GroupFormData("new test");
            group.Footer = "asd";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}