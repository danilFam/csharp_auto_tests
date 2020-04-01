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
                groupCache = ReadGroups();
            }
            return new List<GroupFormData>(groupCache);
        }

        private List<GroupFormData> ReadGroups()
        {
            var groupsList = new List<GroupFormData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> groupElements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement groupElement in groupElements)
            {
                var group = ReadGroup(groupElement);
                groupsList.Add(group);
            }
            return groupsList;
        }

        private GroupFormData ReadGroup(IWebElement groupElement)
        {
            return (new GroupFormData
            {
                Name = groupElement.Text,
                Id = groupElement.FindElement(By.TagName("input")).GetAttribute("value")
            });
        }

        public GroupHelper Modify(int groupToModifyIndex, GroupFormData newData)
        {
            manager.Navigator.GoToGroupsPage();

            CreateGroupIfNotExist();

            SelectGroup(groupToModifyIndex);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int groupToRemoveIndex)
        {
            manager.Navigator.GoToGroupsPage();

            CreateGroupIfNotExist();

            SelectGroup(groupToRemoveIndex);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        private void CreateGroupIfNotExist()
        {
            GroupFormData newGroup = new GroupBuilder().Build();
            bool groupIsNotExist = !IsElementPresent(By.ClassName("group"));

            if (groupIsNotExist)
            {
                Create(newGroup);
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
