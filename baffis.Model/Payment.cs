using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    class Payment
    {
        int IdPayment;
        Order order;
        public double Cost { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
