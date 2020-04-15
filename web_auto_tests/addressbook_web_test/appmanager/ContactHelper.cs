using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public ContactFormData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            ContactFormData contactInformationFromForm = new ContactFormData()
            {
                Firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value"),
                Middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value"),
                Lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value"),
                Nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value"),
                Company = driver.FindElement(By.Name("company")).GetAttribute("value"),
                Title = driver.FindElement(By.Name("title")).GetAttribute("value"),
                Address = driver.FindElement(By.Name("address")).GetAttribute("value"),
                HomePhone = driver.FindElement(By.Name("home")).GetAttribute("value"),
                MobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                WorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value"),
                Email = driver.FindElement(By.Name("email")).GetAttribute("value"),
                Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value"),
                Homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value"),
                Address2 = driver.FindElement(By.Name("address2")).GetAttribute("value"),
                Fax = driver.FindElement(By.Name("fax")).GetAttribute("value"),
                Phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value"),
                Notes = driver.FindElement(By.Name("notes")).GetAttribute("value")
            };
            return contactInformationFromForm;
        }

        public ContactFormData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            ShowContactDetails(index);
            string allInformation = driver.FindElement(By.CssSelector("div#content")).Text;
            return new ContactFormData()
            {
                AllInformation = ReplaceSpecialSymbolsWithEmptyString(allInformation)
            };
        }

        private static string ReplaceSpecialSymbolsWithEmptyString(string allInformation)
        {
            return Regex.Replace(allInformation, @"[\n\t\r\s]", "");
        }

        public ContactFormData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index - 1]
                 .FindElements(By.TagName("td"));
            ContactFormData contactInformationFromTable = new ContactFormData()
            {
                Lastname = cells[1].Text,
                Firstname = cells[2].Text,
                Address = cells[3].Text,
                AllEmails = cells[4].Text,
                AllPhones = cells[5].Text
            };
            return contactInformationFromTable;
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
                contactCache = ReadContacts();
            }
            return new List<ContactFormData>(contactCache);
        }

        private List<ContactFormData> ReadContacts()
        {
            var contactsList = new List<ContactFormData>();
            ICollection<IWebElement> contactElements = driver.FindElements(By.CssSelector("tr[name=entry]"));
            foreach (IWebElement contactElement in contactElements)
            {
                var contact = ReadContact(contactElement);
                contactsList.Add(contact);
            }
            return contactsList;
        }

        private ContactFormData ReadContact(IWebElement contactElement)
        {
            return (new ContactFormData
            {
                Lastname = contactElement.FindElement(By.CssSelector("td:nth-of-type(2)")).Text,
                Firstname = contactElement.FindElement(By.CssSelector("td:nth-of-type(3)")).Text,
                Id = contactElement.FindElement(By.TagName("input")).GetAttribute("id")
            });
        }

        public ContactHelper Modify(ContactFormData newData, int contactToModifyIndex)
        {
            CreateContactIfNotExists();

            InitContactModification(contactToModifyIndex);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        public ContactHelper Remove(int contactToRemoveIndex)
        {
            CreateContactIfNotExists();

            SelectContact(contactToRemoveIndex);
            RemoveContact();
            manager.Navigator.OpenHomePage();

            return this;
        }

        private void CreateContactIfNotExists()
        {
            var newContact = new ContactBuilder().Build();
            bool contactIsNotExist = !IsElementPresent(By.CssSelector("td[class=center]"));

            if (contactIsNotExist)
            {
                Create(newContact);
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
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
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
        private void ShowContactDetails(int index)
        {
            driver.FindElement(By.XPath("(//td[@class='center']//*[@title='Details'])[" + index + "]")).Click();
        }
    }
}
