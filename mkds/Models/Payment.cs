using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Payment
    {
        public Customized_Subscription customized_subscription;
        public Customer customer;
        public Payment_Option option;
        public double price;
        public DateTime date;

        public Payment(Customized_Subscription customizedSubscription, Customer customer, Payment_Option option, double price)
        {
            customized_subscription = customizedSubscription;
            this.customer = customer;
            this.option = option;
            this.price = price;
            this.date = DateTime.Now;
        }
    }
}