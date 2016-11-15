using SSCMP.Repository;
using SSCMP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Service
{
    public class TestService : ITestService
    {
        private IEmployeeRepository _employeeRepository;

        public TestService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        // 流程測試
        public void InsertEmployee()
        {
            _employeeRepository.Insert();
        }

    }
}
