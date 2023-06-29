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
    internal class Reservation : IReservation
    {
        //variable
        public string ReservationId { get; } //id unique
        public DateTime CreateAt { get; }
        public List<IOrderLine> OrdersLines { get; }
        public bool IsAvailable { get; } // true = disponible /false = en attente?

        //constructor
        public Reservation(string id, List<IOrderLine> order,bool isAvailable)
        {
            ReservationId = id;
            CreateAt = DateTime.Now;
            OrdersLines = order;
            IsAvailable = isAvailable;
        }

        
        
    }
}
