using System;
using System.Text;
using System.Collections.Generic;

namespace SSCMP.Domain.Entity
{    
    public class CoachPost 
    {
        public virtual int PostId { get; set; }
        public virtual string CoachId { get; set; }
        public virtual string IsOpen { get; set; }
        public virtual string HopeStudentSex { get; set; }
        public virtual string Memo { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
    }
}
