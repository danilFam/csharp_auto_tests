using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_test
{
    [SetUpFixture]
    public class TestSuitFixture
    {

        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.OpenHomePage();
            app.Auth.Login("admin", "secret");
        }
    }
}