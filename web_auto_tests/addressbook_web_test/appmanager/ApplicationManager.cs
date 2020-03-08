using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_test
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
        public IWebDriver Driver => driver;

        public void Stop()
        {
            driver.Quit();
        }
        public LoginHelper Auth => loginHelper;
        public NavigationHelper Navigator => navigationHelper;
        public GroupHelper Groups => groupHelper;
        public ContactHelper Contacts => contactHelper;
    }
}
