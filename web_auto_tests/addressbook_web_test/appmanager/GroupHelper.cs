using OpenQA.Selenium;
using System.Collections.Generic;

namespace addressbook_web_test
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public GroupHelper Create(GroupFormData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public double GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupFormData> groupCache = null;

        public List<GroupFormData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupFormData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> groupElements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in groupElements)
                {
                    groupCache.Add(new GroupFormData
                    {
                        Name = element.Text,
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupFormData>(groupCache);
        }

        public GroupHelper Modify(int groupToModifyIndex, GroupFormData newData, GroupFormData group)
        {
            manager.Navigator.GoToGroupsPage();

            CreateGroupIfNotExist(group);

            SelectGroup(groupToModifyIndex);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int groupToRemoveIndex, GroupFormData group)
        {
            manager.Navigator.GoToGroupsPage();

            CreateGroupIfNotExist(group);

            SelectGroup(groupToRemoveIndex);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        private void CreateGroupIfNotExist(GroupFormData group)
        {
            bool groupIsNotExist = !IsElementPresent(By.ClassName("group"));

            if (groupIsNotExist)
            {
                Create(group);
            }
        }

        public GroupHelper SelectGroup(int groupToRemoveIndex)
        {
            driver.FindElement(By.XPath("(//span[@class='group']/*[@type='checkbox'])[" + groupToRemoveIndex + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupFormData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
