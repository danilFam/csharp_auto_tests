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
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string tittle = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            return new ContactFormData()
            {
                Firstname = firstName,
                Middlename = middleName,
                Lastname = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Nickname = nickname,
                Company = company,
                Homepage = homePage,
                Address2 = address2,
                Fax = fax,
                Phone2 = phone2,
                Title = tittle,
                Notes = notes
            };
        }

        public ContactFormData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            ShowContactDetails(index);
            string allInformation = driver.FindElement(By.CssSelector("div#content")).Text;
            return new ContactFormData()
            {
                AllInformation = Regex.Replace(allInformation, @"[\n\t\r\s]", "")
            };
        }

        public ContactFormData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index - 1]
                 .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactFormData()
            {
                Firstname = firstName,
                Lastname = lastName,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

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
