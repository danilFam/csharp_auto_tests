using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager manager) 
            : base (manager)
        {
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
