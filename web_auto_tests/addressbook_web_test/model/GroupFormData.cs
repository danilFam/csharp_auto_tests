using System;
namespace addressbook_web_test
{
    public class GroupFormData : IEquatable<GroupFormData>, IComparable<GroupFormData>
    {
        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
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
    }
}
