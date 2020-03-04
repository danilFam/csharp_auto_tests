using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class NavigationHelper : HelperBase
    {

        public NavigationHelper(IWebDriver driver) : base (driver)
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
