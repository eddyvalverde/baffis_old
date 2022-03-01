using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.Model;
using Microsoft.AspNetCore.Mvc;

namespace baffis.DataAccess.Interface
{
    interface ISubscription
    {
        IEnumerable<Subscription> List();

        IActionResult Create(Subscription item);
        Subscription Read(Subscription item);

        Subscription Update(Subscription item);

        Subscription Delete(Subscription item);
    }
}
