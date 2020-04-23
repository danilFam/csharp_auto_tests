using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Linq;

namespace addressbook_web_test
{
    [Table(Name = "group_list")]
    public class GroupFormData : IEquatable<GroupFormData>, IComparable<GroupFormData>
    {
        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public bool Equals(GroupFormData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int CompareTo(GroupFormData other)
        {
            if (other is null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<GroupFormData> GetAllGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
    }
}
