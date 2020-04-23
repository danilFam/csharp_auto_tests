using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_test
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupFormData> fromUI = app.Groups.GetGroupList();
                List<GroupFormData> FromDB = GroupFormData.GetAllGroups();
                fromUI.Sort();
                FromDB.Sort();
                Assert.AreEqual(fromUI, FromDB);
            }
        }
    }
}
