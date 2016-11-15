using System;
using System.Text;
using System.Collections.Generic;

namespace SSCMP.Domain.Entity
{    
    public class AreaData 
    {
        public virtual int AreaId { get; set; }
        public virtual string AreaName { get; set; }
        public virtual int TreeLevel { get; set; }
        public virtual int OrderNumber { get; set; }
        public virtual int AreaParentId { get; set; }
    }
}
