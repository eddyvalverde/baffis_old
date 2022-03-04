using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace baffis.BusinessLogic
{
    public class Order : IOrder
    {
        #region Atributos
        DataAccess.Interface.ISubscription itemDataAccess;
        #endregion
        public Order(DataAccess.Interface.ISubscription itemDataAccess)
        {
            this.itemDataAccess = itemDataAccess;
        }
        public IActionResult Create(Model.Order item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(Model.Order item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Order> List()
        {
            throw new NotImplementedException();
        }

        public IActionResult Read(Model.Order item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Model.Order item)
        {
            throw new NotImplementedException();
        }
    }
}
