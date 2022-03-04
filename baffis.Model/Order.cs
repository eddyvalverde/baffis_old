using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    public class Order
    {
        public Subscription Subscription;
        public string Subscriber;
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int PaymentDay;
        public double Cost { get; set; }
    }
}
