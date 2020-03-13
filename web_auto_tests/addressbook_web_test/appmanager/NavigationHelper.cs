using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public void OpenHomePage()
        {
            if(driver.Url == "http://localhost/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == "http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
