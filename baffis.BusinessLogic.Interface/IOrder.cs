﻿using baffis.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.BusinessLogic.Interface
{
    public interface IOrder
    {
        IEnumerable<baffis.Model.Order> List();
        IActionResult Create(Order item);
        IActionResult Read(Order item);

        IActionResult Update(Order item);

        IActionResult Delete(Order item);
        IActionResult isSubscribed(string subscriber);
    }
}
