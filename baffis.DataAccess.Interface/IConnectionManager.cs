using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.DataAccess.Interface
{
    interface IConnectionManager
    {
        IDbConnection CreateConnection(string keyName);
    }
}
