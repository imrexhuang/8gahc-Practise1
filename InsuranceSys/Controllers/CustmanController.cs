using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsuranceSys.Models;
using InsuranceSys.Models.ViewModels;
using InsuranceSys.Service;


namespace InsuranceSys.Controllers
{
    public class CustmanController : Controller
    {
        private DBEntities db = new DBEntities();

        private readonly CustomerService _customerService;

        public CustmanController()
        {
            _customerService = new CustomerService();
        }
        
        // 實作完成
        public ActionResult Index()
        {
            return View(_customerService.ListCustomerFirstPage());
        }

        // GET: Custman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_customerService.ListCustomerDetails(id));
        }

        // *********   以下程式碼尚未完成**********//
        //TODO:以下功能待完成

        // POST: Custman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Custid,CustCountry,ROCID,PASSPOART_CODE,PASSPOART_NO,Sex,CustNameLocal,CustNameEn,PhoneHomeAreaCode,PhoneHome,PhoneHomeExt,PhoneCorpAreaCode,PhoneCorp,PhoneCorpExt,PhoneMobileATW,AddressPermanent,AddressPermanentZipcode,AddressCorrespondence,AddressCorrespondenceZipcode,Email")] CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomerData(customerViewModel);

                //db.CustomerViewModels.Add(customerViewModel);
                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(customerViewModel);
        }

        // GET: Custman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModels = db.CustomerViewModels.Find(id);
            if (customerViewModels == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModels);
        }

        // POST: Custman/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Custid,CustCountry,ROCID,PASSPOART_CODE,PASSPOART_NO,Sex,CustNameLocal,CustNameEn,PhoneHomeAreaCode,PhoneHome,PhoneHomeExt,PhoneCorpAreaCode,PhoneCorp,PhoneCorpExt,PhoneMobileATW,AddressPermanent,AddressPermanentZipcode,AddressCorrespondence,AddressCorrespondenceZipcode,Email")] CustomerViewModel customerViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerViewModels);
        }

        // GET: Custman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModels = db.CustomerViewModels.Find(id);
            if (customerViewModels == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModels);
        }

        // POST: Custman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerViewModel customerViewModels = db.CustomerViewModels.Find(id);
            db.CustomerViewModels.Remove(customerViewModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
