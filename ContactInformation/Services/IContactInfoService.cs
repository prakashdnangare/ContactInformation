using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformation.Services
{
    public interface IContactInfoService
    {
        List<ContactInfo> GetContactInfo();
        ContactInfo GetContactInfo(Guid Id);
        ContactInfo CreateContact(ContactInfo contactInfo);
        ContactInfo GetEditContact(Guid Id);
        ContactInfo EditContact(ContactInfo contactInfo);
        ContactInfo GetDeleteContact(Guid Id);
        void DeleteConfirmContact(Guid Id);
    }
}
