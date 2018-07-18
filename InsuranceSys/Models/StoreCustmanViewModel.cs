using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

/* 
 *處理『 LINQ to Entities 查詢中無法建構實體或複雜類型 』
 https://dotblogs.com.tw/leo_codespace/2017/07/20/163800
 https://dotblogs.com.tw/awws/2014/02/21/144109
 https://bbs.csdn.net/topics/380105442
 */
namespace InsuranceSys.Models
{
    public class StoreCustmanViewModel
    {

        public StoreCustomer StoreCustomerViewModel { get; set; }

        public StoreCustomerDetail StoreCustomerDetailViewModel { get; set; }

        public class StoreCustomer
        {
            [Key]
            [DisplayName("客戶代號")]
            [Required]
            public int Custid { get; set; }

            [DisplayName("國家/地區別")]
            public string CustCountry { get; set; }

            [DisplayName("身分證/統一編號/統一證號")]
            public string ROCID { get; set; }

            [DisplayName("護照國碼")]
            public string PASSPOART_CODE { get; set; }

            [DisplayName("護照號碼")]
            public string PASSPOART_NO { get; set; }

            [DisplayName("性別")]
            [Required]
            public string Sex { get; set; }

            [DisplayName("客戶姓名(中文/母語)")]
            [Required]
            public string CustNameLocal { get; set; }

            [DisplayName("客戶姓名(英文)")]
            [Required]
            public string CustNameEn { get; set; }

        }

        public class StoreCustomerDetail
        {
            [Key]
            [DisplayName("客戶代號")]
            [Required]
            public int Custid { get; set; }

            [DisplayName("居住電話(區碼)")]
            public string PhoneHomeAreaCode { get; set; }

            [DisplayName("居住電話")]
            public string PhoneHome { get; set; }

            [DisplayName("居住電話(分機)")]
            public string PhoneHomeExt { get; set; }

            [DisplayName("公司電話(區碼)")]
            public string PhoneCorpAreaCode { get; set; }

            [DisplayName("公司電話")]
            public string PhoneCorp { get; set; }

            [DisplayName("公司電話(分機)")]
            public string PhoneCorpExt { get; set; }

            [DisplayName("行動電話(台灣)")]
            public string PhoneMobileATW { get; set; }

            [DisplayName("戶籍/永久地址")]
            public string AddressPermanent { get; set; }

            [DisplayName("戶籍/永久地址郵遞區號")]
            public string AddressPermanentZipcode { get; set; }

            [DisplayName("通訊地址")]
            public string AddressCorrespondence { get; set; }

            [DisplayName("通訊地址郵遞區號")]
            public string AddressCorrespondenceZipcode { get; set; }

            [DisplayName("電子郵件")]
            public string Email { get; set; }

        }
    }
}