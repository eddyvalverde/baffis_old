using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.Model
{
    public class Subscription
    {
        public int IdSubscription { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public Currency Currency { get; set; }

        public Subscription(Currency currency)
        {
            Currency = currency;
        }

        public Subscription()
        {
        }

        public Subscription(int idSubscription, string title, string description, decimal cost, Currency currency)
        {
            IdSubscription = idSubscription;
            Title = title;
            Description = description;
            Cost = cost;
            Currency = currency;
        }
        public Subscription(int idSubscription)
        {
            IdSubscription = idSubscription;
        }

    }
}
