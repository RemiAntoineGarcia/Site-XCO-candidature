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



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            

        }

        //Teste à effectuer
        static Boolean test1() 
        {
            OrderLine ordertest = new OrderLine("Idtest1", 1);
            List<IOrderLine> orders = new List<IOrderLine>();
            orders.Add(ordertest);
            Reservation reservation = new Reservation("IDres1", orders, true);
            Console.WriteLine("test1  :");
            Console.WriteLine("ProductId = " + ordertest.ProductId + "  :  Quantity = " + ordertest.Quantity );

            Console.WriteLine("ID = " + reservation.ReservationId + "_ time =" + reservation.CreateAt.ToString() + "_ IsAvailible =" + reservation.IsAvailable.ToString());
            return true;
        }
    }
}
