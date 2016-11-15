using System;
using System.Text;
using System.Collections.Generic;

namespace SSCMP.Domain.Entity
{
    public class UserAccount
    {
        public virtual string UserId { get; set; }
        public virtual string Role { get; set; }
        public virtual string LoginPassword { get; set; }
        public virtual string Sex { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual string Email { get; set; }
        public virtual int? AddressCounty { get; set; }
        public virtual int? AddressTownship { get; set; }
        public virtual string AddressDetail { get; set; }
        public virtual string MobilePhone { get; set; }
        public virtual string Memo { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
    }
}
