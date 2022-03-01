using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    class Order
    {
        Subscription Subscription;
        string Buyer;
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        int PaymentDay;
    }
}
