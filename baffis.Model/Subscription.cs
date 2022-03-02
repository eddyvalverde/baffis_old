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
        public double Cost { get; set; }
        public Currency Currency { get; set; }
    }
}
