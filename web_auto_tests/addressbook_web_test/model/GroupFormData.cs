namespace addressbook_web_test
{
    public class GroupFormData
    {
        public string Name { get; set; }
        public string Header { get; set; } = "";
        public string Footer { get; set; } = "";

        public GroupFormData(string name)
        {
            this.Name = name;
        }

    }
}
