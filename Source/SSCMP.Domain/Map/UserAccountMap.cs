using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;

namespace SSCMP.Domain.Maps 
{        
    public class UserAccountMap : ClassMap<UserAccount> 
    {        
        public UserAccountMap() {
			Table("USER_ACCOUNT");
			LazyLoad();
			Id(x => x.UserId).GeneratedBy.Assigned().Column("USER_ID");
			Map(x => x.Role).Column("ROLE").Not.Nullable().Length(10);
			Map(x => x.LoginPassword).Column("LOGIN_PASSWORD").Not.Nullable();
			Map(x => x.Sex).Column("SEX").Not.Nullable().Length(1);
			Map(x => x.Birthday).Column("BIRTHDAY").Not.Nullable();
			Map(x => x.Email).Column("EMAIL").Not.Nullable().Length(100);
			Map(x => x.AddressCounty).Column("ADDRESS_COUNTY").Precision(10);
			Map(x => x.AddressTownship).Column("ADDRESS_TOWNSHIP").Precision(10);
			Map(x => x.AddressDetail).Column("ADDRESS_DETAIL").Length(100);
			Map(x => x.MobilePhone).Column("MOBILE_PHONE").Length(20);
			Map(x => x.Memo).Column("MEMO");
			Map(x => x.CreateDate).Column("CREATE_DATE").Not.Nullable();
			Map(x => x.LastLoginDate).Column("LAST_LOGIN_DATE");
			Map(x => x.ModifyDate).Column("MODIFY_DATE");
        }
    }
}
