using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baffis.Model;
using Microsoft.AspNetCore.Mvc;

namespace baffis.DataAccess.Interface
{
    public interface ICurrency
    {
        IEnumerable<baffis.Model.Currency> List();
        IActionResult Create(Currency item);
        IActionResult Read(Currency item);

        IActionResult Update(Currency item);

        IActionResult Delete(Currency item);
    }
}
