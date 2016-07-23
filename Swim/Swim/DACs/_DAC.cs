using System;
using System.Linq;
using System.Data.Linq;
using Swim.Models;
using System.Configuration;
using System.Text;

namespace Swim.DAC
{
    /// <summary>
    /// Data Access and Control
    /// </summary>
    public class _DAC : IDisposable
    {
        protected DataContext dbConn;

        public _DAC()
        {
            dbConn = new DataContext(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        /// <summary>
        /// 關閉連結與釋放資源
        /// </summary>
        public void Dispose()
        {
            dbConn.Connection.Close();
            dbConn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}