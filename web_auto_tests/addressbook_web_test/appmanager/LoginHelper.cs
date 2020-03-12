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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(username))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), username);
            Type(By.Name("pass"), password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        public bool IsLoggedIn(string username)
        {
            return IsLoggedIn()
                  &&
                  driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                  == "(" + username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
