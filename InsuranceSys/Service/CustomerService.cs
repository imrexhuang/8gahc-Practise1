using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceSys.Models;
using InsuranceSys.Models.ViewModels;

namespace InsuranceSys.Service
{
    public class CustomerService
    {
        public List<CustomerViewModel> ListCustomerFirstPage()
        {
            using (var db = new DBEntities())
            {
                var cust = (from cd in db.CustomerD
                            join cm in db.CustomerM
                            on cd.Custid equals cm.Custid
                            // https://stackoverflow.com/questions/10548505/linq-select-and-convert-entites-to-viewmodels
                            //select new  //這樣會有CS0029錯誤，無法轉型
                            select new CustomerViewModel
                            {
                                CustomerMViewModel = new CustomerMViewModel
                                {
                                    Custid = cm.Custid,
                                    CustCountry = cm.CustCountry,
                                    ROCID = cm.ROCID,
                                    PASSPOART_CODE = cm.PASSPOART_CODE,
                                    PASSPOART_NO = cm.PASSPOART_NO,
                                    Sex = cm.Sex,
                                    CustNameLocal = cm.CustNameLocal,
                                    CustNameEn = cm.CustNameEn,
                                },
                                CustomerDViewModel = new CustomerDViewModel
                                {
                                    Custid = cd.Custid,
                                    PhoneHomeAreaCode = cd.PhoneHomeAreaCode,
                                    PhoneHome = cd.PhoneHome,
                                    PhoneHomeExt = cd.PhoneHomeExt,
                                    PhoneCorpAreaCode = cd.PhoneCorpAreaCode,
                                    PhoneCorp = cd.PhoneCorp,
                                    PhoneCorpExt = cd.PhoneCorpExt,
                                    PhoneMobileATW = cd.PhoneMobileATW,
                                    AddressPermanent = cd.AddressPermanent,
                                    AddressPermanentZipcode = cd.AddressPermanentZipcode,
                                    AddressCorrespondence = cd.AddressCorrespondence,
                                    AddressCorrespondenceZipcode = cd.AddressCorrespondenceZipcode,
                                    Email = cd.Email
                                }                         

                            }).Take(20).ToList();
                             // }).Take(20).OrderBy(x => x.CustomerMViewModel.Custid).ToList();  //會有錯誤 System.NotSupportedException: LINQ to Entities

                return cust.ToList();
            }
        }

        public CustomerViewModel ListCustomerDetails(int? custid)
        {

            using (var db = new DBEntities())
            {
                var cust = (from cd in db.CustomerD
                            join cm in db.CustomerM
                            on cd.Custid equals cm.Custid
                            where cm.Custid == custid
                            select new CustomerViewModel
                            {
                                CustomerMViewModel = new CustomerMViewModel
                                {
                                    Custid = cm.Custid,
                                    CustCountry = cm.CustCountry,
                                    ROCID = cm.ROCID,
                                    PASSPOART_CODE = cm.PASSPOART_CODE,
                                    PASSPOART_NO = cm.PASSPOART_NO,
                                    Sex = cm.Sex,
                                    CustNameLocal = cm.CustNameLocal,
                                    CustNameEn = cm.CustNameEn,
                                },
                                CustomerDViewModel = new CustomerDViewModel
                                {
                                    Custid = cd.Custid,
                                    PhoneHomeAreaCode = cd.PhoneHomeAreaCode,
                                    PhoneHome = cd.PhoneHome,
                                    PhoneHomeExt = cd.PhoneHomeExt,
                                    PhoneCorpAreaCode = cd.PhoneCorpAreaCode,
                                    PhoneCorp = cd.PhoneCorp,
                                    PhoneCorpExt = cd.PhoneCorpExt,
                                    PhoneMobileATW = cd.PhoneMobileATW,
                                    AddressPermanent = cd.AddressPermanent,
                                    AddressPermanentZipcode = cd.AddressPermanentZipcode,
                                    AddressCorrespondence = cd.AddressCorrespondence,
                                    AddressCorrespondenceZipcode = cd.AddressCorrespondenceZipcode,
                                    Email = cd.Email
                                }
                            }).First();
                return  cust;
            }
        }

        public void CreateCustomerData(CustomerViewModel custmodel)
        {
            using (var db = new DBEntities())
            {
                db.CustomerM.Add(custmodel.CustomerMViewModel);
                db.CustomerD.Add(custmodel.CustomerDViewModel);
                db.SaveChanges();
            }
        }

    }
}