using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public void Login(string username, string password)
        {
            Type(By.Name("user"), username);
            Type(By.Name("pass"), password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
