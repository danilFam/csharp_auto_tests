using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            app.Auth.Login("admin", "secret");
            Assert.IsTrue(app.Auth.IsLoggedIn("admin"));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();

            app.Auth.Login("adminn", "secret");
            Assert.IsFalse(app.Auth.IsLoggedIn("admin"));
        }

    }
}
