using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Customized_Subscription
    {
        public int monday;
        public int tuesday;
        public int wednesday;
        public int thursday;
        public int friday;
        public int saturday;
        public int sunday;
        public Subscription subscription;
        public Customer customer;
        public string address;
        public string notes;
        public string schedule_time;
        public double total_price;
    }
}