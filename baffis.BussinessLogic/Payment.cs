using baffis.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.BusinessLogic
{
    public class Payment : IPayment
    {
        #region Atributos
        DataAccess.Interface.IPayment itemDataAccess;
        #endregion
        public Payment(DataAccess.Interface.IPayment itemDataAccess)
        {
            this.itemDataAccess = itemDataAccess;
        }
        public IActionResult Create(Model.Payment item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Payment> List()
        {
            return itemDataAccess.List();
        }
    }
}
