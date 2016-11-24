using SSCMP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Repository.Interface
{
    /// <summary>
    /// AreaData Repository
    /// </summary>
    public abstract class AbstractAreaDataRepository 
    {
        public abstract IList<AreaData> ReadAll();
    



    }
}
