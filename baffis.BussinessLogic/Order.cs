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
        DataAccess.Interface.IOrder itemDataAccess;
        #endregion
        public Order(DataAccess.Interface.IOrder itemDataAccess)
        {
            this.itemDataAccess = itemDataAccess;
        }
        public IActionResult Create(Model.Order item)
        {
            return itemDataAccess.Create(item);
        }

        public IActionResult Delete(Model.Order item)
        {
            return itemDataAccess.Delete(item);
        }

        public IActionResult isSubscribed(string subscriber)
        {
            return itemDataAccess.isSubscribed(subscriber);
        }

        public IEnumerable<Model.Order> List()
        {
            return itemDataAccess.List();
        }

        public IActionResult Read(Model.Order item)
        {
            return itemDataAccess.Read(item);
        }

        public IActionResult Update(Model.Order item)
        {
            return itemDataAccess.Update(item);
        }
    }
}
