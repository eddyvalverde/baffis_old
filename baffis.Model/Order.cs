using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    public class Order
    {
        public int IDOrder { get; set; }
        public Subscription Subscription { get; set; }
        public string Subscriber { get; set; }
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int PaymentDay { get; set; }
        public decimal Cost { get; set; }

        public Order(int id)
        {
            IDOrder = id;
        }
        public Order(string subscriber)
        {
            Subscriber = subscriber;
        }
        public Order()
        {
        }

    }
}
