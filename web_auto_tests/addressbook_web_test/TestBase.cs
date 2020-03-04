using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace addressbook_web_test
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

    }
}
