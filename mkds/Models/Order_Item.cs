using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Order_Item
    {
        public Order order;
        public Ingredient ingredient;
        public double amount;

        public Order_Item(Order order, Ingredient ingredient, double amount)
        {
            this.order = order;
            this.ingredient = ingredient;
            this.amount = amount;
        }

    }
}