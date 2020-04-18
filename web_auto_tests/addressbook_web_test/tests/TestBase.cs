using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Text;

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

        [TearDown]
        public void TakeScreenShotIfTestFails()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var fileName = TestContext.CurrentContext.TestDirectory + "\\" +
                               DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-FFF") + "-" + GetType().Name + "-" +
                               TestContext.CurrentContext.Test.MethodName + "." + ScreenshotImageFormat.Jpeg;
                try
                {
                    ((ITakesScreenshot)app.Driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                    TestContext.AddTestAttachment(fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

    }
}
