using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{
    /// <summary>
    /// state of the product's Stock
    /// </summary>
    internal class Inventory : IInventory
    {
        public string ProductId { get; }
        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }

        public Inventory(string productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
            ReservedQuantity =0;
        }
    }
}
