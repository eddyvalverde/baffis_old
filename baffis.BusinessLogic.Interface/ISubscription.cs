using baffis.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.BusinessLogic.Interface
{
    public interface ISubscription
    {
        IEnumerable<baffis.Model.Subscription> List();
        IActionResult Create(Subscription item);
        IActionResult Read(Subscription item);

        IActionResult Update(Subscription item);

        IActionResult Delete(Subscription item);
    }
}
