//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceSys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneCorpAreaCode { get; set; }
        public string PhoneCorp { get; set; }
        public string PhoneCorpExt { get; set; }
        public string Department { get; set; }
        public string SysRole { get; set; }
    }
}
