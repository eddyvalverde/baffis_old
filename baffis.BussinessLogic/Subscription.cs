﻿using baffis.BusinessLogic.Interface;
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
            throw new NotImplementedException();
        }

        public IActionResult Delete(Model.Subscription item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Subscription> List()
        {
            return itemDataAccess.List();
        }

        public IActionResult Read(Model.Subscription item)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Model.Subscription item)
        {
            throw new NotImplementedException();
        }
    }
}