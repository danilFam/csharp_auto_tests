using NUnit.Framework;

namespace addressbook_web_test
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetUpLogin()
        {
            app.Auth.Login("admin", "secret");
        }
    }
}
