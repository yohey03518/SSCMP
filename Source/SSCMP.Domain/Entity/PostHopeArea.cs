using System;
using System.Text;
using System.Collections.Generic;

namespace SSCMP.Domain.Entity
{    
    public class PostHopeArea 
    {
        public virtual int Id { get; set; }
        public virtual string PostCharacter { get; set; }
        public virtual int PostId { get; set; }
        public virtual int AreaId { get; set; }
    }
}
