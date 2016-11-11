using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCCMP.Domain.Entity;
using SCCMP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCCMP.Test
{
    [TestClass]
    public class FluentNhibernateTest
    {
        [TestMethod]
        public void FluentNhibernateInsertDataTest()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var DepartmentObject = new Department { Name = "IT", PhoneNumber = "962788700227" };
                    session.Save(DepartmentObject);
                    transaction.Commit();
                    Console.WriteLine("Department Created: " + DepartmentObject.Name);
                }
            }
        }
    }
}
