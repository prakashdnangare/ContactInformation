using ContactInformationCore;
using ContactInformationCore.Data.Container;
using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContactInformation.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContextFactory _contextFactory;
        public ContactInfoService(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public List<ContactInfo> GetContactInfo()
        {
            using (var context = _contextFactory.GetContaxt())
            {
                return context.ContactInfo.ToList();
            }
        }

        public ContactInfo GetContactInfo(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                if (Id == null)
                {                    
                }
                return context.ContactInfo.Where(x => x.Id == Id).FirstOrDefault();
            }
        }        
        public ContactInfo CreateContact(ContactInfo contactInfo)
        {
            using (var context = _contextFactory.GetContaxt())
            {                
                var ContactInfoContext = new ContactInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = contactInfo.FirstName,
                    LastName = contactInfo.LastName,
                    Email = contactInfo.Email,
                    Phone = contactInfo.Phone,
                    Status = contactInfo.Status
                };
                context.ContactInfo.Add(ContactInfoContext);
                context.SaveChanges();               
            }
            return contactInfo;
        }

        public ContactInfo GetEditContact(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                ContactInfo contactInfo = context.ContactInfo.Find(Id);
                return contactInfo;
            }            
        }

        public ContactInfo EditContact(ContactInfo contactInfo)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                context.Entry(contactInfo).State = EntityState.Modified;
                context.SaveChanges();
            }
            return contactInfo;
        }

        public ContactInfo GetDeleteContact(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                ContactInfo contactInfo = context.ContactInfo.Find(Id);                              
                return contactInfo;
            }
        }

        public void DeleteConfirmContact(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                ContactInfo contactInfo = context.ContactInfo.Find(Id);
                if (contactInfo != null)
                {
                    context.ContactInfo.Remove(contactInfo);
                    context.SaveChanges();
                }               
            }            
        }
    }
}