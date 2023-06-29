using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Site_CXO_candidature
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("launch test!");
            if (test1()) 
            { 
                Console.WriteLine("test1   :  OK"); 
            }
            else { Console.WriteLine("test1   :  ERREUR"); }

            if(test2()) 
            {
                Console.WriteLine("test2   :  OK");
            }
            else { Console.WriteLine("test2   :  ERREUR"); }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            

        }

        //Teste à effectuer
        static Boolean test1() //création test
        {
            BackEndservice backEndservice = new BackEndservice();

            //create inventory
            Inventory inventory = new Inventory("IdObj1", 4);
            backEndservice.Inventorys.Add(inventory); // add to Inventorys
            
            //create orderLine
            OrderLine ordertest = new OrderLine("IdObj1", 1);
            //create Order liste
            List<IOrderLine> orders = new List<IOrderLine>();
            orders.Add(ordertest);


            //create reservation
            IReservation reservation1 = backEndservice.CreateReservation(orders);
            backEndservice.Reservations.Add(reservation1);



            Console.WriteLine();
            Console.WriteLine("test1  :");
            Console.WriteLine();
            Console.WriteLine("Inventory1 ::    ProductId = " + backEndservice.Inventorys[0].ProductId + "    :   Quantity = " + backEndservice.Inventorys[0].Quantity );
            Console.WriteLine("OrderLine1 ::    ProductId = " + ordertest.ProductId +                    "    :   Quantity = " + ordertest.Quantity);
            foreach (IReservation reservation in backEndservice.Reservations)
            {
                Console.WriteLine("Reservati1 ::     ID = " + reservation.ReservationId + "       time = " + reservation.CreateAt.ToString() + "       IsAvailible = " + reservation.IsAvailable.ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
            return true;
        }

        static Boolean test2() //création List test
        {
            BackEndservice backEndservice = new BackEndservice();

            //create inventory
            for(int i = 0; i < 10; i++)
            {
            Inventory inventory1 = new Inventory("IdObj"+i.ToString(), 4);
            backEndservice.Inventorys.Add(inventory1); // add to Inventorys
            }

            
            for (int i = 0; i < 10; i++)
            {
                //create Order liste
                List<IOrderLine> orders = new List<IOrderLine>();
                for (int y = 0; y < i; y++)
                {
                    //create orderLine
                    OrderLine ordertest = new OrderLine("IdObj"+y.ToString(), 1);

                    orders.Add(ordertest);
                }
                //create reservation
                IReservation reservation1 = backEndservice.CreateReservation(orders);
                backEndservice.Reservations.Add(reservation1);
            }



            Console.WriteLine();
            Console.WriteLine("test1  :");
            Console.WriteLine();
            
            Console.WriteLine();
            foreach (IInventory inventory in backEndservice.Inventorys)
            {
                Console.WriteLine("Inventory1 ::    ProductId = " + inventory.ProductId + "    :   Quantity = " + inventory.Quantity);
            }
            Console.WriteLine();
            foreach (IReservation reservation in backEndservice.Reservations)
            {
                Console.WriteLine("Reservati1 ::     ID = " + reservation.ReservationId + "       time = " + reservation.CreateAt.ToString() + "       IsAvailible = " + reservation.IsAvailable.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            return true;

            return true;
        }

        static Boolean test3() //error in list test
        {

            return true;
        }
    }
}
