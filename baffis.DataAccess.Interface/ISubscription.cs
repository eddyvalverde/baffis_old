using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.Model;
using Microsoft.AspNetCore.Mvc;

namespace baffis.DataAccess.Interface
{
    public interface ISubscription
    {
        IEnumerable<Subscription> List();

        IActionResult Create(Subscription item);
        IActionResult Read(Subscription item);

        IActionResult Update(Subscription item);

        IActionResult Delete(Subscription item);
    }
}
