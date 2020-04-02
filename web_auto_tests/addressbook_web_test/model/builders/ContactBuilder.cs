using Bogus;

namespace addressbook_web_test
{
    public class ContactBuilder
    {
        private ContactFormData contact;

        public ContactBuilder()
        {
            this.contact = CreateContactDefaultModel();
        }

        public ContactFormData Build()
        {
            return this.contact;
        }

        private ContactFormData CreateContactDefaultModel()
        {
            var contact = new Faker<ContactFormData>()
                .RuleFor(c => c.Firstname, f => f.Name.FirstName())
                .RuleFor(c => c.Homepage, f => f.Lorem.Word())
                .RuleFor(c => c.MobilePhone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Lastname, f => f.Name.LastName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Company, f => f.Company.CompanyName())
                .RuleFor(c => c.Address2, f => f.Address.StreetAddress())
                .Generate();
            return contact;
        }
    }
}
