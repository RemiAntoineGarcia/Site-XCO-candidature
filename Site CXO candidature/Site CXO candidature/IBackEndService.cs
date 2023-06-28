using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace Site_CXO_candidature
{
    internal interface IBackEndService
    {
        IReservation CreateReservation(List<IOrderLine> order);
        List<I>
    }

    /// <summary>
    /// 
    /// </summary>
    class Reservation
    {
        string ReservationId { get; }
        DateTime CreaetAt { get; }
        List<OrderLine> OrdersLines { get; }
        bool IsAvailable { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    class Inventory
    {
        string ProductId { get; }
        int Quantity { get; set; }
    }

    ///
    class OrderLine
    {
        string ProductId { get; }
        int Quantity { get; set; }
    }



}