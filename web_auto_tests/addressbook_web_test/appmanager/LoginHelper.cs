using OpenQA.Selenium;

namespace addressbook_web_test
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) 
            : base (manager)
        {
        }

        public void Login(string username, string password)
        {
            driver.FindElement(By.Name("user")).SendKeys(username);
            driver.FindElement(By.Name("pass")).SendKeys(password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
