using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CellPhoneX_2100009273.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        //Contructor
        public Cart(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}