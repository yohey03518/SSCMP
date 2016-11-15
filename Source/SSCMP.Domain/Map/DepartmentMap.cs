using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Domain.Map
{
   class DepartmentMap : ClassMap<Department>
    {
        //Constructor
        public DepartmentMap()
        {
            // ID自動產生
            Id(x => x.Id).GeneratedBy.Increment(); ;

            Map(x => x.Name);

            Map(x => x.PhoneNumber);

            Table("Department");
        }
    }
}
