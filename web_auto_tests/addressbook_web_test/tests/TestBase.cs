using NUnit.Framework;

namespace addressbook_web_test
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetUpApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
