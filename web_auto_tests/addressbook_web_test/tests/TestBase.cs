using NUnit.Framework;

namespace addressbook_web_test
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetUp()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        protected void TearDown()
        {
            app.Stop();
        }

    }
}
