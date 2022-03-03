using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    public class Currency
    {
        public Currency(int idCurrency)
        {
            IdCurrency = idCurrency;
        }

        public Currency()
        {
        }
        [ColumnName("IdCurrency")]
        public int IdCurrency { get; set; }
        public string Name { get; set; }
        public string SYMBOL { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
    }
}
