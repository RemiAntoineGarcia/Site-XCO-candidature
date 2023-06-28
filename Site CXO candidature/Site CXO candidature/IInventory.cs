using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{
    internal interface IInventory
    {
        string ProductId { get; }
        int Quantity { get; set; }
        int ReservedQuantity { get; set; }
    }
}
