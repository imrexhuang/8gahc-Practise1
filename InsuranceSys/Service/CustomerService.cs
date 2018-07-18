using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceSys.Models;
using InsuranceSys.Repository;
using static InsuranceSys.Models.StoreCustmanViewModel;

namespace InsuranceSys.Service
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerDetail> _customerDetailRepository;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _customerRepository = new Repository<Customer>(unitOfWork);
            _customerDetailRepository = new Repository<CustomerDetail>(unitOfWork);
        }

        //public List<CustmanViewModel> ListCustomerFirstPage()
        public List<StoreCustmanViewModel> ListCustomerFirstPage()
        {
            //return new List<CustmanViewModel>(); //回傳空的List，開發時沒資料庫使用

            using (var db = new ModelContext())
            {
                    List<StoreCustmanViewModel> cust = new List<StoreCustmanViewModel>();

                    cust = (from cm in db.Customer
                            join cd in db.CustomerDetail
                            on cm.Custid equals cd.Custid
                            //select new CustmanViewModel
                            select new StoreCustmanViewModel
                            {
                                //CustomerViewModel = new Customer
                                StoreCustomerViewModel = new StoreCustomer
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
                                //CustomerDetailViewModel = new CustomerDetail
                                StoreCustomerDetailViewModel = new StoreCustomerDetail
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
                return cust.ToList();
            }

        }


        public StoreCustmanViewModel ListCustomerDetails(int? custid)
        {

            using (var db = new ModelContext())
            {
                var cust = (from cm in db.Customer
                            join cd in db.CustomerDetail
                            on cm.Custid equals cd.Custid
                            where cm.Custid == custid
                            select new StoreCustmanViewModel
                            {
                                StoreCustomerViewModel = new StoreCustomer
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
                                StoreCustomerDetailViewModel = new StoreCustomerDetail
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

        public void CreatePOC1(Customer cust)
        {
            _customerRepository.Create(new Customer
            {
                Custid = cust.Custid,
                CustCountry = cust.CustCountry,
                ROCID = cust.ROCID,
                PASSPOART_CODE = cust.PASSPOART_CODE,
                PASSPOART_NO = cust.PASSPOART_NO,
                Sex = cust.Sex,
                CustNameLocal = cust.CustNameLocal,
                CustNameEn = cust.CustNameEn,
            });
        }

        public void CreatePOC2(CustomerDetail cust)
        {
            _customerDetailRepository.Create(new CustomerDetail
            {
                Custid = cust.Custid,
                PhoneHomeAreaCode = cust.PhoneHomeAreaCode,
                PhoneHome = cust.PhoneHome,
                PhoneHomeExt = cust.PhoneHomeExt,
                PhoneCorpAreaCode = cust.PhoneCorpAreaCode,
                PhoneCorp = cust.PhoneCorp,
                PhoneCorpExt = cust.PhoneCorpExt,
                PhoneMobileATW = cust.PhoneMobileATW,
                AddressPermanent = cust.AddressPermanent,
                AddressPermanentZipcode = cust.AddressPermanentZipcode,
                AddressCorrespondence = cust.AddressCorrespondence,
                AddressCorrespondenceZipcode = cust.AddressCorrespondenceZipcode,
                Email = cust.Email
            });
        }

        public void CreateCustomerData(CustmanViewModel cust)
        {
            _customerRepository.Create(new Customer
            {
                Custid = cust.CustomerViewModel.Custid,
                CustCountry = cust.CustomerViewModel.CustCountry,
                ROCID = cust.CustomerViewModel.ROCID,
                PASSPOART_CODE = cust.CustomerViewModel.PASSPOART_CODE,
                PASSPOART_NO = cust.CustomerViewModel.PASSPOART_NO,
                Sex = cust.CustomerViewModel.Sex,
                CustNameLocal = cust.CustomerViewModel.CustNameLocal,
                CustNameEn = cust.CustomerViewModel.CustNameEn,
            });

            _customerDetailRepository.Create(new CustomerDetail
            {
                Custid = cust.CustomerDetailViewModel.Custid,
                PhoneHomeAreaCode = cust.CustomerDetailViewModel.PhoneHomeAreaCode,
                PhoneHome = cust.CustomerDetailViewModel.PhoneHome,
                PhoneHomeExt = cust.CustomerDetailViewModel.PhoneHomeExt,
                PhoneCorpAreaCode = cust.CustomerDetailViewModel.PhoneCorpAreaCode,
                PhoneCorp = cust.CustomerDetailViewModel.PhoneCorp,
                PhoneCorpExt = cust.CustomerDetailViewModel.PhoneCorpExt,
                PhoneMobileATW = cust.CustomerDetailViewModel.PhoneMobileATW,
                AddressPermanent = cust.CustomerDetailViewModel.AddressPermanent,
                AddressPermanentZipcode = cust.CustomerDetailViewModel.AddressPermanentZipcode,
                AddressCorrespondence = cust.CustomerDetailViewModel.AddressCorrespondence,
                AddressCorrespondenceZipcode = cust.CustomerDetailViewModel.AddressCorrespondenceZipcode,
                Email = cust.CustomerDetailViewModel.Email
            });

        }


        public void EditCustomerData(int id, CustmanViewModel cust)
        {
            //var oldData = _orderRepository.GetSingle(d => d.Id == id);
        }

    }
}