using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsuranceSys.Models;
using InsuranceSys.Service;
using InsuranceSys.Repository;

namespace InsuranceSys.Controllers
{
    public class CustmanController : Controller
    {
        private DBEntities db = new DBEntities();

        private readonly CustomerService _customerService;
        private readonly UnitOfWork _unitOfWork;

        public CustmanController()
        {
            _unitOfWork = new UnitOfWork();
            _customerService = new CustomerService(_unitOfWork);
        }
        
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


        /*  TODO:以下尚修修改完成 */
        // POST: Custman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Custid,CustCountry,ROCID,PASSPOART_CODE,PASSPOART_NO,Sex,CustNameLocal,CustNameEn,PhoneHomeAreaCode,PhoneHome,PhoneHomeExt,PhoneCorpAreaCode,PhoneCorp,PhoneCorpExt,PhoneMobileATW,AddressPermanent,AddressPermanentZipcode,AddressCorrespondence,AddressCorrespondenceZipcode,Email")] CustmanViewModel CustmanViewModel)
        {
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomerData(CustmanViewModel);

                return RedirectToAction("Index");
            }

            return View(CustmanViewModel);
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
