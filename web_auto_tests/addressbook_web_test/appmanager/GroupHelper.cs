using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(GroupFormData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
