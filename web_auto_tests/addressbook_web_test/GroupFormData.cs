using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test
{
    class GroupFormData
    {
        string name;
        string header="";
        string footer="";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Header
        {
            get { return header;}
            set { header = value; }
        }
        public string Footer
        {
            get { return footer; }
            set { footer = value; }
        }
       
        public GroupFormData(string name)
        {
            this.name = name;
        }
        
    }
}
