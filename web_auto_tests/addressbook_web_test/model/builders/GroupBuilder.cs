using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test
{
    public class GroupBuilder
    {
        private GroupFormData group;

        public GroupBuilder()
        {
            this.group = CreateGroupDefaultModel();
        }
        public GroupFormData Build()
        {
            return this.group;
        }

        private GroupFormData CreateGroupDefaultModel()
        {
            var group = new Faker<GroupFormData>()
                .RuleFor(g => g.Name, f => f.Name.FirstName())
                .RuleFor(g => g.Header, f => f.Name.LastName())
                .RuleFor(g => g.Footer, f => f.Internet.UserName())
                .Generate();
                return group;
        }
    }
}
