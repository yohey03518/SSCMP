using SSCMP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Repository
{
    // 測試EmployeeRepository
    public class EmployeeRepository : IEmployeeRepository
    {
        // 測試新增Employee
        public void Insert()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var EmployeeDepartment = new Department
                    {
                        Name = "TTTT",
                        PhoneNumber = "962788700227"
                    };
                    var Employee = new Employee
                    {
                        FirstName = "Chris",
                        Position = "GSS",
                        EmployeeDepartment = EmployeeDepartment,
                    };
                    // 需先儲存Department
                    session.Save(EmployeeDepartment);
                    // 再儲存Employee
                    session.Save(Employee);
                    transaction.Commit();
                }
            }
        }
    }
}
