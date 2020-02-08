using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class ShopCartItem
    {
        public string product_name { get; set; }
        public string product_quantity { get; set; }
        public string product_price { get; set; }
        public string product_id { get; set; }
        public string unique_key { get; set; }
    }
}