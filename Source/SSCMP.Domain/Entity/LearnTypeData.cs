using System;
using System.Text;
using System.Collections.Generic;

namespace SSCMP.Domain.Entity
{    
    public class LearnTypeData 
    {
        public virtual int TypeId { get; set; }
        public virtual string TypeName { get; set; }
        public virtual int TreeLevel { get; set; }
        public virtual int OrderNumber { get; set; }
        public virtual int TypeParentId { get; set; }
    }
}
