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
        public List<IReservation> Reservations; //list of all Reservations
        public List<IInventory> Inventorys; //list of all Inventory

        public int LastReservationID;
        //limit fixer arbitrairement
        int defaultLimitReservation = 10;
        int defaultLimitInventory = 30;
        // constructor
        public BackEndservice()
        {
            Reservations = new List<IReservation>();
            Inventorys = new List<IInventory>();

            //add data to the list
            //supose to fech in the data base
            
        }



        ///interface's function
        ///public fonction (front or external used)

        //create a reservation
        public IReservation CreateReservation(List<IOrderLine> order)  
        {
            //fuze double
            List<IOrderLine> orderChecked = new List<IOrderLine>();
            foreach (IOrderLine orderLine in order)
            {
                if (Inventorys.FindIndex(x => x.ProductId == orderLine.ProductId) != -1) //check if the productId exist in the Inventory
                {

                    IOrderLine newOrderLine = new OrderLine(orderLine.ProductId, 0);
                    foreach (IOrderLine orderLine2 in order.FindAll(x => x.ProductId == orderLine.ProductId))
                    {
                        newOrderLine.Quantity += orderLine2.Quantity;
                    }
                    orderChecked.Add(newOrderLine);
                }
                else
                {
                    return null;// cancel the reservation if th productId don't exist (we can also juste delete this part to create the reservation without the problemetic element)
                }
            }

            string id = generatReservationID();
            bool isAvailable = reserveOrder(orderChecked);
            Reservation reservation = new Reservation(id, orderChecked, isAvailable);

            //send to the database


            return reservation;
        }
        //get a part of the réservation's List
        public List<IReservation> GetReservations(int cursor, int limit) 
        {
            //get the list
            List<IReservation> partReservations = Reservations.GetRange(cursor, limit);

            //return the list
            return partReservations;
        }
        //
        public void setInventory(string productId, int quantity)
        {
            int indexToModify = Inventorys.FindIndex(x => x.ProductId == productId);
            Inventorys[indexToModify].Quantity = quantity; 
        }
        
        public List<IInventory> GetInventory(int cursor, int limit)
        {
            //get the list
            List<IInventory> partInventory = Inventorys.GetRange(cursor, limit);

            //return the list
            return partInventory;
        }
        
        //Call whenever the Inventoty is update
        public void onUpdateInventory()
        {
            //check if the reservation that are not available can be put available
            foreach (IReservation reservation in Reservations.FindAll(x => x.IsAvailable == false))//possible obtimisation : find only the reservation that contain the change product
            {
                Reservations.Find(x => x.ReservationId == reservation.ReservationId).IsAvailable = reserveOrder(reservation.OrdersLines);
            }
        }

        //private fonction(internal used
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
                    //since it's cheched in CreateReservation before it's not supposed to append
                    Console.WriteLine("Error CheckOrder: invalid order, inexisting productId");
                    return false; 
                }
            }
            return true;
        }
        // check the order and
        private bool reserveOrder(List<IOrderLine> order)
        {
            if (checkOrder(order))
            {
                foreach (OrderLine orderLine in order)
                {
                    int index = Inventorys.FindIndex(x => x.ProductId == orderLine.ProductId);
                    Inventorys[index].ReservedQuantity += orderLine.Quantity;
                }
                return true;
            }
            else 
            { return false; }
        }
    }
}
