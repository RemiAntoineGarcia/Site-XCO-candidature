using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site_CXO_candidature
{

    internal class BackEndservice : IBackEndService
    {
        //Variable
        public List<IReservation> Reservations;
        public List<IInventory> Inventorys;

        public int LastReservationID;

        int defaultLimitReservation = 10;
        int defaultLimitInventory = 30;
        // constructor
        public BackEndservice() 
        {
            Reservations = GetReservations(0, defaultLimitReservation);
            Inventorys = GetInventory(0, defaultLimitInventory);
        }



        ///interface's function
        ///public fonction

        //create a reservation
        public IReservation CreateReservation(List<IOrderLine> order) 
        {
            string id = generatReservationID();
            bool isAvailable = checkOrder(order);
            Reservation reservation = new Reservation(id, order, isAvailable);

            //send to the database


            return reservation;
        }
        //get a part of the réservation's List
        public List<IReservation> GetReservations(int cursor, int limit) 
        {
            //List<IReservation> reservations
            //verifie if the cursor and cursor +limit is out of the List


            //get the list


            //return the list
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


        //private fonction
        //generate a unique ID
        private string generatReservationID()
        {
            LastReservationID = +1;
            string ID = LastReservationID.ToString();

            // code pour une génération aléatoire. demande l'intégralité des réservations
            /*string possibleChar = "0123456789ABCDEF";
            int len = possibleChar.Length;

            bool unique = false;
            while (unique)
            {
                //generate the ID
                for (int i = 0; i < 4; i++)
                { 
                    int index = new Random().Next(0, len-1);
                    ID = ID + possibleChar.ToCharArray()[index].ToString();
                }
                //check the id
                if (Reservations.Find(x => x.ReservationId == ID) == null)
                {
                    unique = true;
                }
                else 
                {
                    ID = "";
                }
            }*/

                return ID;
        }
        // check if all item are availible
        private bool checkOrder(List<IOrderLine> order)
        {

            foreach (OrderLine orderLine in order)
            {
                IInventory inventory = Inventorys.Find(x => x.ProductId == orderLine.ProductId);
                if (inventory != null)
                {
                    //check if the quantity is enough
                    if (inventory.Quantity < inventory.ReservedQuantity + orderLine.Quantity)
                    { 
                        return false;
                    }
                }
                else
                { 
                    Console.WriteLine("Error CheckOrder: invalid order");
                    return false; 
                }
            }
            return true;
        }
    }
}
