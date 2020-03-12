using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace addressbook_web_test
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            driver.Quit();
        }
        public IWebDriver Driver => driver;

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public LoginHelper Auth => loginHelper;
        public NavigationHelper Navigator => navigationHelper;
        public GroupHelper Groups => groupHelper;
        public ContactHelper Contacts => contactHelper;
    }
}
