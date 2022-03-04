using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.Model;
using Microsoft.AspNetCore.Mvc;

namespace baffis.BusinessLogic.Interface
{
    public interface IPayment
    {
        IEnumerable<Payment> List();
        IActionResult Create(Payment item);
    }
}
