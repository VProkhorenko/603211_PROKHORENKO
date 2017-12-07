using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _603211_PROKHORENKO.DAL.Entities;

namespace _603211_PROKHORENKO.Models
{
    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}
