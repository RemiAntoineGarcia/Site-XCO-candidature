using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{
    internal interface IBackEndService
    {
        IReservation CreateReservation(List<IOrderLine> order);

        //get the réservation's List from the database(html in this case)
        List<IReservation> GetReservations(int cursor, int limit);
        void setInventory(string productId, int limit);

        List<IInventory> GetInventory(int cursor, int limit);
        
    }

}