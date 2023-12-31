﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IReservation
    {
        string ReservationId { get; } //id unique
        DateTime CreateAt { get; }
        List<IOrderLine> OrdersLines { get; }
        bool IsAvailable { get; set; } // true = disponible /false = en attente?

    }
}
