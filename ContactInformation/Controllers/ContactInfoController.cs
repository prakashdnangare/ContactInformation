using ContactInformation.Services;
using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContactInformation.Controllers
{
    public class ContactInfoController : Controller
    {
        private IContactInfoService _contactInfoService;
        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public ActionResult GetContactInfo()
        {
            var ContactInfoList = _contactInfoService.GetContactInfo();
            return View(ContactInfoList);
        }
        public ActionResult Details(Guid Id)
        {
            var ContactInfo = _contactInfoService.GetContactInfo(Id);
            if (ContactInfo != null)
            {
                return View(ContactInfo);
            }
            return HttpNotFound();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContactInfo contactInfo)
        {
            if (!String.IsNullOrEmpty(contactInfo.FirstName)
                || !String.IsNullOrEmpty(contactInfo.LastName)
                || !String.IsNullOrEmpty(contactInfo.Email)
                || !String.IsNullOrEmpty(contactInfo.Phone)
                || !String.IsNullOrEmpty(contactInfo.Status))
            {
                _contactInfoService.CreateContact(contactInfo);

            }
            return RedirectToAction("GetContactInfo");
        }

        public ActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = _contactInfoService.GetEditContact(Id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        [HttpPost]
        public ActionResult Edit(ContactInfo contactInfo)
        {
            if (!String.IsNullOrEmpty(contactInfo.FirstName)
                || !String.IsNullOrEmpty(contactInfo.LastName)
                || !String.IsNullOrEmpty(contactInfo.Email)
                || !String.IsNullOrEmpty(contactInfo.Phone)
                || !String.IsNullOrEmpty(contactInfo.Status))
            {
                _contactInfoService.EditContact(contactInfo);

            }
            return RedirectToAction("GetContactInfo");
        }

        public ActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = _contactInfoService.GetDeleteContact(Id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            _contactInfoService.DeleteConfirmContact(Id);
            return RedirectToAction("GetContactInfo");
        }
    }
}