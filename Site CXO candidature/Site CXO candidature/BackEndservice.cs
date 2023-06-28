using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{

    internal class BackEndservice : IBackEndService
    {

        // constructeur
        public BackEndservice() 
        { 
        }
        public IReservation CreateReservation(List<IOrderLine> order) 
        {
            return null;
        }
        //get the réservation's List from the database(html in this case)
        public List<IReservation> GetReservations(int cursor, int limit) 
        {
            return null;
        }
        public void setInventory(string productId, int limit)
        {
            
        }
        public List<IInventory> GetInventory(int cursor, int limit)
        {
            return null;
        }
        //get the réservation from the database(html in this case)
    }
}
