using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    public class Order
    {
        Subscription Subscription;
        string Subscriber;
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        int PaymentDay;
        public double Cost { get; set; }
    }
}
