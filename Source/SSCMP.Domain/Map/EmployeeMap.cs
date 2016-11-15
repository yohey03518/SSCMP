using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Domain.Map
{
    class EmployeeMap : ClassMap<Employee>
    {
        //Constructor
        public EmployeeMap()
        {
            // ID自動產生
            Id(x => x.Id).GeneratedBy.Increment(); ;

            Map(x => x.FirstName);

            Map(x => x.Position);

            References(x => x.EmployeeDepartment).Column("DepartmentId");

            Table("Employee");
        }
    }
}
