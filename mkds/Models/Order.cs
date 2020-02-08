using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Order
    {
        public int order_id;
        public Meal meal;
        public Carrier carrier;


        public Order(int order_id, Meal meal, Carrier carrier)
        {
            this.order_id = order_id;
            this.meal = meal;
            this.carrier = carrier;
        }

    }
}