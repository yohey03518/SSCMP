using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;

namespace SSCMP.Domain.Maps
{       
    public class StudentPostMap : ClassMap<StudentPost> 
    {        
        public StudentPostMap() {
			Table("STUDENT_POST");
			LazyLoad();
			Id(x => x.PostId).GeneratedBy.Identity().Column("POST_ID");
			Map(x => x.CoachId).Column("COACH_ID").Not.Nullable().Length(20);
			Map(x => x.IsOpen).Column("IS_OPEN").Not.Nullable().Length(1);
			Map(x => x.HopeCoachSex).Column("HOPE_COACH_SEX").Not.Nullable().Length(1);
			Map(x => x.Memo).Column("MEMO").Not.Nullable();
			Map(x => x.CreateDate).Column("CREATE_DATE").Not.Nullable();
			Map(x => x.ModifyDate).Column("MODIFY_DATE");
        }
    }
}
