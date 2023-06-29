using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{
    internal class OrderLine : IOrderLine
    {
        //variable
        public string ProductId { get;}
        public int Quantity { get; set; }

        //Constructor
        public OrderLine(string id, int quantity) 
        { 
            ProductId = id;
            Quantity = quantity;
        }
        //Functions
    }
}
