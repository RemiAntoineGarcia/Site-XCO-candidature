using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{
    /// <summary>
    /// 
    /// </summary>
    public class Reservation
    {
        string ReservationId { get; } //id unique
        DateTime CreateAt { get; }
        List<OrderLine> OrdersLines { get; }
        bool IsAvailable { get; } // true = disponible /false = en attente?

    }
}
