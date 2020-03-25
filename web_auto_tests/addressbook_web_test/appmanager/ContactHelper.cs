using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;

namespace addressbook_web_test
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactFormData contact)
        {
            InitAddNewContact();
            FillContactForm(contact);
            SubmitContactForm();
            ReturnToHomePage();
            return this;
        }

        public double GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name=entry]")).Count;
        }

        private List<ContactFormData> contactCache = null;

        public List<ContactFormData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactFormData>();
                ICollection<IWebElement> contactElements = driver.FindElements(By.CssSelector("tr[name=entry]"));
                foreach (IWebElement contactElement in contactElements)
                {
                    contactCache.Add(new ContactFormData
                    {
                        Lastname = contactElement.FindElement(By.CssSelector("td:nth-of-type(2)")).Text,
                        Firstname = contactElement.FindElement(By.CssSelector("td:nth-of-type(3)")).Text,
                        Id = contactElement.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactFormData>(contactCache);
        }

        public ContactHelper Modify(ContactFormData newData, int contactToModifyIndex, ContactFormData contact)
        {
            CreateContactIfNotExists(contact);

            InitContactModification(contactToModifyIndex);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        public ContactHelper Remove(int contactToRemoveIndex, ContactFormData contact)
        {
            CreateContactIfNotExists(contact);

            SelectContact(contactToRemoveIndex);
            RemoveContact();
            manager.Navigator.OpenHomePage();

            return this;
        }

        private void CreateContactIfNotExists(ContactFormData contact)
        {
            bool contactIsNotExist = !IsElementPresent(By.CssSelector("td[class=center]"));

            if (contactIsNotExist)
            {
                Create(contact);
            }
        }

        public ContactHelper InitAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactFormData contact)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"images\", "newimage.png");
            driver.FindElement(By.CssSelector("input[type=file]")).SendKeys(path);
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[name=submit]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int contactToRemoveIndex)
        {
            driver.FindElement(By.XPath("(//td[@class='center']/*[@type='checkbox'])[" + contactToRemoveIndex + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//td[@class='center']//*[@title='Edit'])[" + index + "]")).Click();
            return this;
        }
    }
}
