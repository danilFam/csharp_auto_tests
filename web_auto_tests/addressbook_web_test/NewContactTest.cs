using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace addressbook_web_test
{
    [TestFixture]
    public class NewContactTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void NewContact()
        {
            OpenHomePage();
            Login("admin", "secret");
            InitAddNewContact();
            ContactFormData contact = new ContactFormData("another new contact");
            contact.Lastname = "qwe";
            contact.Address = "street";
            contact.Email = "qwe@ewq.com";
            contact.Company = "best company";
            FillContactForm(contact);
            SubmitContactForm();
            ReturnToHomePage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[name=submit]")).Click();
        }

        private void FillContactForm(ContactFormData contact)
        {
            var path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, @"images\", "newimage.png");
            driver.FindElement(By.CssSelector("input[type=file]")).SendKeys(path);
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
        }

        private void InitAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(string username, string password)
        {
            driver.FindElement(By.Name("user")).SendKeys(username);
            driver.FindElement(By.Name("pass")).SendKeys(password);
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
            driver.Manage().Window.Size = new System.Drawing.Size(758, 984);
        }
    }
}