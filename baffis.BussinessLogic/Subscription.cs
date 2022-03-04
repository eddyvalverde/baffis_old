using baffis.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.BusinessLogic
{
    public class Subscription : ISubscription
    {
        #region Atributos
        DataAccess.Interface.ISubscription itemDataAccess;
        #endregion
        public Subscription(DataAccess.Interface.ISubscription itemDataAccess)
        {
            this.itemDataAccess = itemDataAccess;
        }
        public IActionResult Create(Model.Subscription item)
        {
            return itemDataAccess.Create(item);
        }

        public IActionResult Delete(Model.Subscription item)
        {
            return itemDataAccess.Delete(item);
        }

        public IEnumerable<Model.Subscription> List()
        {
            return itemDataAccess.List();
        }

        public IActionResult Read(Model.Subscription item)
        {
            return itemDataAccess.Read(item);
        }

        public IActionResult Update(Model.Subscription item)
        {
            return itemDataAccess.Update(item);
        }
    }
}
